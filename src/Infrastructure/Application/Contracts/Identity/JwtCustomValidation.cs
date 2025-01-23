using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Application.Contracts.Identity
{
    public class JwtCustomValidation
    {
        protected IUnitOfWork UnitOfWork { get; }

        public JwtCustomValidation(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }


        public async Task Validate(TokenValidatedContext context)
        {
            var signInManager = context.HttpContext.RequestServices.GetRequiredService<SignInManager<ApplicationUser>>();
            var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();

            var claimsIdentity = context.Principal?.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims.Any() != true)
                context.Fail("This token has no claims.");

            var securityStamp = claimsIdentity!.FindFirstValue(new ClaimsIdentityOptions().SecurityStampClaimType);
            if (!securityStamp.HasValue())
                context.Fail("This token has no security stamp");

            //Find user and token from database and perform your custom validation
            var userId = claimsIdentity!.GetUserId<string>();
            var user = await userManager.FindByIdAsync(userId);

            var validatedUser = await signInManager.ValidateSecurityStampAsync(context.Principal);
            if (validatedUser == null)
                context.Fail("Token security stamp is not valid.");

            if (user == null || user.PhoneNumberConfirmed == false)
            {
                context.Fail("User is inActive");
                return;
            }

            if (user.UserIsBlocked)
                context.Fail("User is blocked.");

            if (userManager.SupportsUserLockout && user.LockoutEnabled)
                context.Fail("User is locked out.");

            var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var hashJwtToken = Security.GetSha256Hash(jwtToken);

            var token = await UnitOfWork.UserTokensRepository.GetByPredicate(u => u.HashJwtToken == hashJwtToken);

            if (token == null)
            {
                context.Fail("Token not found");
                return;
            }
        }
    }
}
