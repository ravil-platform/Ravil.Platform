using Resources.Messages;

namespace Application.Contracts.Identity
{
    public class JwtService : IJwtService
    {
        protected SiteSettings SiteSetting { get; }
        protected SignInManager<ApplicationUser> SignInManager { get; }

        public JwtService(IOptionsSnapshot<SiteSettings> settings, SignInManager<ApplicationUser> signInManager)
        {
            SiteSetting = settings.Value;
            SignInManager = signInManager;
        }

        public async Task<AccessToken> GenerateAsync(ApplicationUser user)
        {
            var secretKey = Encoding.UTF8.GetBytes(SiteSetting.JwtSettings.SecretKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encryptionkey = Encoding.UTF8.GetBytes(SiteSetting.JwtSettings.EncryptKey);
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = await _getClaimsAsync(user);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = SiteSetting.JwtSettings.Issuer,
                Audience = SiteSetting.JwtSettings.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(SiteSetting.JwtSettings.NotBeforeMinutes),
                Expires = DateTime.Now.AddMinutes(SiteSetting.JwtSettings.ExpirationMinutes),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);

            return new AccessToken(securityToken);
        }

        public JwtSecurityToken? DecodeToken(string token)
        {
            var encryptionKey = Encoding.UTF8.GetBytes(SiteSetting.JwtSettings.EncryptKey);
            var secretKey = Encoding.UTF8.GetBytes(SiteSetting.JwtSettings.SecretKey);

            var validationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero, // default: 5 min
                RequireSignedTokens = true,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ValidateAudience = true, //default : false
                ValidAudience = SiteSetting.JwtSettings.Audience,

                ValidateIssuer = true, //default : false
                ValidIssuer = SiteSetting.JwtSettings.Issuer,

                TokenDecryptionKey = new SymmetricSecurityKey(encryptionKey),
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                var jwtToken = validatedToken as JwtSecurityToken;

                return jwtToken;
            }
            catch (Exception ex)
            {
                Console.WriteLine(Resources.Messages.Validations.JwtDecodeTokenIsInvalid, ex.Message);
            }

            return null;
        }

        private async Task<IEnumerable<Claim>> _getClaimsAsync(ApplicationUser user)
        {
            var result = await SignInManager.ClaimsFactory.CreateAsync(user);

            var list = new List<Claim>(result.Claims);
            list.Add(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber!));

            //JwtRegisteredClaimNames.Sub
            //var securityStampClaimType = new ClaimsIdentityOptions().SecurityStampClaimType;

            //var list = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, user.UserName),
            //    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //    //new Claim(ClaimTypes.MobilePhone, "09123456987"),
            //    //new Claim(securityStampClaimType, user.SecurityStamp.ToString())
            //};

            //var roles = new Role[] { new Role { Name = "Admin" } };
            //foreach (var role in roles)
            //    list.Add(new Claim(ClaimTypes.Role, role.Name));

            return list;
        }
    }
}
