using AngleSharp.Io;
using Application.Services.SMS;
using Constants.Security;
using UAParser;

namespace Application.Features.User.Commands.RegisterOrLogin;

public class RegisterOrLoginUserCommandHandler : IRequestHandler<RegisterOrLoginUserCommand, RegisterUserResponseViewModel>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }
    protected IJwtService JwtService { get; }
    protected ISmsSender SmsSender { get; }
    protected UserManager<ApplicationUser> UserManager { get; }
    protected IHttpContextAccessor HttpContextAccessor { get; }

    public RegisterOrLoginUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IJwtService jwtService, ISmsSender smsSender, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        JwtService = jwtService;
        SmsSender = smsSender;
        UserManager = userManager;
        HttpContextAccessor = httpContextAccessor;
    }


    public async Task<Result<RegisterUserResponseViewModel>> Handle(RegisterOrLoginUserCommand request, CancellationToken cancellationToken)
    {
        var uaParser = Parser.GetDefault();
        var header = HttpContextAccessor.HttpContext.Request.Headers[HeaderNames.UserAgent].ToString();

        var device = "windows";
        if (header != null)
        {
            var info = uaParser.Parse(header);
            device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";
        }

        var currentUser = await UnitOfWork.ApplicationUserRepository
            .GetByPredicate(u => u.PhoneNumber == request.PhoneNumber);
        
        if (currentUser is not null && currentUser.UserIsBlocked || currentUser.LockoutEnabled || currentUser.IsDeleted)
        {
            throw new BadRequestException("حساب کاربری شما مسدود است");
        }

        if (request.SmsCode == null)
        {
            #region ( Register New User Or Send Sms For Existing User  )
            #region (Send Sms For current User )
            if (currentUser is not null)
            {
                var code = Strings.CodeGenerator();
                var responseSms = await SmsSender.SendPattern(currentUser.PhoneNumber, code, "login-code");

                currentUser.OneTimeUseCode = code;
                currentUser.OneTimeUseCodeEnd = DateTime.Now.AddMinutes(2);

                var updateResult = await UserManager.UpdateAsync(currentUser);

                var result = Mapper.Map<RegisterUserResponseViewModel>(currentUser);
                var token = await JwtService.GenerateAsync(currentUser);

                await UnitOfWork.UserTokensRepository.InsertAsync(new UserTokens()
                {
                    UserId = currentUser.Id,
                    HashJwtToken = Security.GetSha256Hash(token.access_token),
                    HashRefreshToken = Security.GetSha256Hash(token.refresh_token),
                    TokenExpireDate = DateTime.Now.AddDays(30),
                    RefreshTokenExpireDate = DateTime.Now.AddDays(40),
                    Device = device
                });

                await UnitOfWork.SaveAsync();

                if (responseSms.Equals("ok"))
                {
                    result.Jwt = new JsonResult(token);

                    return result;
                }
                else
                {
                    throw new BadRequestException("به علت شلوغی خطوط پیامک تایید برای شما ارسال نشد. لطفا دوباره تلاش کنید.");
                }
            }
            #endregion

            #region ( Register User )
            else
            {
                //Register New User

                var user = Mapper.Map<ApplicationUser>(request);

                user.UserName = request.PhoneNumber;
                user.Firstname = "کاربر";
                user.Lastname = "سایت";
                user.Gender = GenderPerson.Other;

                await UserManager.CreateAsync(user);
                await UnitOfWork.SaveAsync();


                var result = Mapper.Map<RegisterUserResponseViewModel>(user);

                var code = await UserManager.GenerateChangePhoneNumberTokenAsync(user, request.PhoneNumber);
                var responseSms = await SmsSender.SendPattern(user.PhoneNumber, code, "activate");

                user.OneTimeUseCode = code;
                user.OneTimeUseCodeEnd = DateTime.Now.AddMinutes(2);

                var updateResult = await UserManager.UpdateAsync(user);

                await UnitOfWork.SaveAsync();

                if (responseSms.Equals("ok"))
                {
                    return result;
                }
                else
                {
                    throw new BadRequestException("به علت شلوغی خطوط پیامک تایید برای شما ارسال نشد. لطفا دوباره تلاش کنید.");
                }
            }
            #endregion
            #endregion
        }
        else
        {
            #region ( Login )
            //check for login
            if (request.SmsCode == currentUser.OneTimeUseCode)
            {
                if (currentUser.OneTimeUseCodeEnd < DateTime.Now)
                {
                    throw new BadRequestException("زمان استفاده از کد به پایان رسیده است");
                }
                else
                {
                    var user = await UnitOfWork.ApplicationUserRepository
                        .GetByPredicate(u => u.PhoneNumber == request.PhoneNumber);

                    var token = await JwtService.GenerateAsync(currentUser);

                    await UnitOfWork.UserTokensRepository.InsertAsync(new UserTokens()
                    {
                        UserId = currentUser.Id,
                        HashJwtToken = Security.GetSha256Hash(token.access_token),
                        HashRefreshToken = Security.GetSha256Hash(token.refresh_token),
                        TokenExpireDate = DateTime.Now.AddDays(Jwt.TokenExpireDate),
                        RefreshTokenExpireDate = DateTime.Now.AddDays(Jwt.RefreshTokenExpireDate),
                        Device = device
                    });

                    await UnitOfWork.SaveAsync();

                    var result = new RegisterUserResponseViewModel
                    {
                        PhoneNumber = user.PhoneNumber,
                        Jwt = new JsonResult(token)
                    };

                    return result;
                }
            }
            else
            {
                throw new BadRequestException("کد وارد شده اشتباه است");
            }

            return new Result<RegisterUserResponseViewModel>();
            #endregion
        }
    }
}