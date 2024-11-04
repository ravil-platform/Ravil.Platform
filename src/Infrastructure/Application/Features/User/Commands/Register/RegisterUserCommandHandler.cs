using Application.Services.SMS;

namespace Application.Features.User.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponseViewModel>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }
    protected IJwtService JwtService { get; }
    protected ISmsSender SmsSender { get; }
    protected UserManager<ApplicationUser> UserManager { get; }

    public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IJwtService jwtService, ISmsSender smsSender, UserManager<ApplicationUser> userManager)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        JwtService = jwtService;
        SmsSender = smsSender;
        UserManager = userManager;
    }

    public async Task<Result<RegisterUserResponseViewModel>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {

        //Todo: Check User Account Is Active and ... 

        var currentUser = await UnitOfWork.ApplicationUserRepository
            .GetByPredicate(u => u.PhoneNumber == request.PhoneNumber);

        if (request.SmsCode == null)
        {
            if (currentUser is not null)
            {
                //Send For Current User

                var code = Strings.CodeGenerator();
                var responseSms = await SmsSender.SendPattern(currentUser.PhoneNumber, code, "login-code");

                currentUser.OneTimeUseCode = code;
                currentUser.OneTimeUseCodeEnd = DateTime.Now.AddMinutes(2);

                var updateResult = await UserManager.UpdateAsync(currentUser);

                var result = Mapper.Map<RegisterUserResponseViewModel>(currentUser);
                var token = await JwtService.GenerateAsync(currentUser);

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
            else
            {
                //Register New User

                var user = Mapper.Map<ApplicationUser>(request);

                user.UserName = request.PhoneNumber;
                user.Firstname = "کاربر";
                user.Lastname = "سایت";
                user.Gender = GenderPerson.Other;

                await UnitOfWork.ApplicationUserRepository.InsertAsync(user);
                await UnitOfWork.SaveAsync();


                var result = Mapper.Map<RegisterUserResponseViewModel>(user);

                var token = await JwtService.GenerateAsync(user);

                var code = await UserManager.GenerateChangePhoneNumberTokenAsync(user, request.PhoneNumber);
                var responseSms = await SmsSender.SendPattern(user.PhoneNumber, code, "activate");

                user.OneTimeUseCode = code;
                user.OneTimeUseCodeEnd = DateTime.Now.AddMinutes(2);

                var updateResult = await UserManager.UpdateAsync(user);

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
        }
        else
        {
            //check for login
            if (request.SmsCode == currentUser.OneTimeUseCode)
            {
                if (currentUser.OneTimeUseCodeEnd < DateTime.Now)
                {
                    throw new BadRequestException("زمان استفاده از کد به پایان رسیده است");
                }
                else
                {
                    //generate token for user and every thing is ok
                }
            }
            else
            {
                throw new BadRequestException("کد وارد شده اشتباه است");
            }

            return new Result<RegisterUserResponseViewModel>();
        }
    }
}