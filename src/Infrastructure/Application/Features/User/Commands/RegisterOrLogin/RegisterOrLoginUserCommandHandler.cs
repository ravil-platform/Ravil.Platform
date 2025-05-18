using Domain.Entities.Wallets;

namespace Application.Features.User.Commands.RegisterOrLogin;

public class RegisterOrLoginUserCommandHandler : IRequestHandler<RegisterOrLoginUserCommand, RegisterOrLoginUserResponseViewModel>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; }
    protected ISmsSender SmsSender { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IJwtService JwtService { get; }
    protected IHttpContextAccessor HttpContextAccessor { get; }
    protected UserManager<ApplicationUser> UserManager { get; }
    protected SignInManager<ApplicationUser> SignInManager { get; }

    #endregion

    #region ( Constructor )

    public RegisterOrLoginUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IJwtService jwtService, ISmsSender smsSender, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        JwtService = jwtService;
        SmsSender = smsSender;
        UserManager = userManager;
        SignInManager = signInManager;
        HttpContextAccessor = httpContextAccessor;
    }

    #endregion

    public async Task<Result<RegisterOrLoginUserResponseViewModel>> Handle(RegisterOrLoginUserCommand request, CancellationToken cancellationToken)
    {
        #region ( Register Or Login User Command )

        var result = new Result<RegisterOrLoginUserResponseViewModel>();

        #region ( Check LogedIn User )
        if (HttpContextAccessor.HttpContext?.User != null && SignInManager.IsSignedIn(HttpContextAccessor.HttpContext?.User!))
        {
            throw new BadRequestException("شما قبلا وارد سایت شده اید");
        }
        #endregion

        #region ( Detect Client DeviceName )
        var device = "windows";
        var uaParser = Parser.GetDefault();
        var header = HttpContextAccessor.HttpContext.Request.Headers[HeaderNames.UserAgent].ToString();

        if (header != null)
        {
            var info = uaParser.Parse(header);
            device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";
        }
        #endregion

        #region ( SignIn/Out Operations )
        var currentUser = await UserManager.FindByNameAsync(request.PhoneNumber);

        if (currentUser is not null)
        {
            if (currentUser.UserIsBlocked || currentUser.LockoutEnabled || currentUser.IsDeleted)
            {
                if (await UserManager.IsLockedOutAsync(currentUser))
                {
                    var resultLockedOutUser = await UserManager.SetLockoutEnabledAsync(currentUser, false);
                    if (!resultLockedOutUser.Succeeded) throw new LockedOutException("حساب کاربری شما مسدود است");
                }
            }
        }

        if (request.SmsCode == null)
        {
            #region ( Register New User Or Send Sms For Existing User  )
            #region (Send Sms For current User )
            if (currentUser is not null)
            {
                #region ( SecurityStamp )

                if (string.IsNullOrWhiteSpace(currentUser.SecurityStamp))
                {
                    await UserManager.UpdateSecurityStampAsync(currentUser);
                }

                #endregion

                #region ( Check Confirm Account )

                string codeVerification;
                if (!await UserManager.IsPhoneNumberConfirmedAsync(currentUser))
                {
                    codeVerification = await UserManager.GenerateChangePhoneNumberTokenAsync(currentUser, request.PhoneNumber);
                }
                else codeVerification = Strings.CodeGenerator();

                #endregion

                var responseSms = await SmsSender.SendPattern(currentUser.PhoneNumber, codeVerification, "login-code");

                currentUser.OneTimeUseCode = codeVerification;
                currentUser.OneTimeUseCodeEnd = DateTime.Now.AddMinutes(2);

                var updateResult = await UserManager.UpdateAsync(currentUser);

                result.WithValue(Mapper.Map<RegisterOrLoginUserResponseViewModel>(currentUser));

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

            //Register New User
            #region ( Register User )
            else
            {
                var user = Mapper.Map<ApplicationUser>(request);

                user.UserName = request.PhoneNumber;
                user.Firstname = "کاربر";
                user.Lastname = "راویل";
                user.Gender = GenderPerson.Other;
                user.LockoutEnabled = false;

                await UserManager.CreateAsync(user);
                await UnitOfWork.SaveAsync();

                #region ( Create Wallet For User )

                var userWallet = new Wallet
                {
                    Inventory = 0,
                    ApplicationUserId = user.Id,
                };
                await UnitOfWork.WalletRepository.InsertAsync(userWallet);
                await UnitOfWork.SaveAsync();

                #endregion

                result.WithValue(Mapper.Map<RegisterOrLoginUserResponseViewModel>(user));

                var code = await UserManager.GenerateChangePhoneNumberTokenAsync(user, request.PhoneNumber);

                var responseSms = await SmsSender.SendPattern(user.PhoneNumber, code, "activate");

                user.OneTimeUseCode = code;
                user.OneTimeUseCodeEnd = DateTime.Now.AddMinutes(2);

                await UserManager.UpdateSecurityStampAsync(user);

                var updateResult = await UserManager.UpdateAsync(user);

                if (!updateResult.Succeeded)
                {
                    result.WithErrors(updateResult.Errors.Select(a => a.Description).ToList());
                    return result;
                }

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
                    if (!await UserManager.IsPhoneNumberConfirmedAsync(currentUser))
                    {
                        #region ( SecurityStamp )
                        var validatedUser = await SignInManager.ValidateSecurityStampAsync(currentUser, currentUser.SecurityStamp);
                        if (!validatedUser)
                        {
                            await UserManager.UpdateSecurityStampAsync(currentUser);
                        }
                        #endregion

                        var resultConfirmation = await UserManager.ChangePhoneNumberAsync(currentUser, request.PhoneNumber, request.SmsCode);

                        if (resultConfirmation.Succeeded)
                        {
                            currentUser.ConfirmationDate = DateTime.Now;
                            currentUser.UpdateDate = DateTime.Now;
                            currentUser.PhoneNumberConfirmed = true;

                            var updateResult = await UserManager.UpdateAsync(currentUser);
                            if (!updateResult.Succeeded)
                            {
                                result.WithErrors(updateResult.Errors.Select(a => a.Description).ToList());
                                return result;
                            }
                        }
                        else
                        {
                            throw new BadRequestException("عملیات با خطا مواجه شد. کد وارد شده صحیح نیست.");
                        }
                    }
                    else
                    {
                        currentUser.UpdateDate = DateTime.Now;
                        currentUser.ConfirmationDate = DateTime.Now;

                        #region ( SecurityStamp )

                        var validatedUser = await SignInManager.ValidateSecurityStampAsync(currentUser, currentUser.SecurityStamp);
                        if (!validatedUser)
                        {
                            await UserManager.UpdateSecurityStampAsync(currentUser);
                        }

                        #endregion

                        var updateResult = await UserManager.UpdateAsync(currentUser);
                        if (!updateResult.Succeeded)
                        {
                            result.WithErrors(updateResult.Errors.Select(a => a.Description).ToList());
                            return result;
                        }
                    }

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

                    await SignInManager.SignInAsync(currentUser, true);

                    result.WithValue(new RegisterOrLoginUserResponseViewModel
                    {
                        Id = Guid.Parse(currentUser.Id),
                        PhoneNumber = currentUser.PhoneNumber,
                        Jwt = new JsonResult(token)
                    });

                    return result;
                }
            }
            else
            {
                throw new BadRequestException("کد وارد شده اشتباه است");
            }
            #endregion
        }
        #endregion

        #endregion
    }
}