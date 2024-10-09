namespace Application.Contracts.Identity
{
    public class JwtService : IJwtService
    {
        protected SiteSettings SiteSettings { get; }
        //protected SignInManager<User> SignInManager { get; }

        //public JwtService(IOptionsSnapshot<SiteSettings> settings, SignInManager<User> signInManager)
        //{
        //    SiteSettings = settings.Value;
        //    SignInManager = signInManager;
        //}

        //public async Task<AccessToken> GenerateAsync(User user)
        //{
        //    var secretKey = Encoding.UTF8.GetBytes(SiteSettings.JwtSettings.SecretKey); // longer that 16 character
        //    var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

        //    var encryptionkey = Encoding.UTF8.GetBytes(SiteSettings.JwtSettings.EncryptKey); //must be 16 character
        //    var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

        //    var claims = await _getClaimsAsync(user);

        //    var descriptor = new SecurityTokenDescriptor
        //    {
        //        Issuer = SiteSettings.JwtSettings.Issuer,
        //        Audience = SiteSettings.JwtSettings.Audience,
        //        IssuedAt = DateTime.Now,
        //        NotBefore = DateTime.Now.AddMinutes(SiteSettings.JwtSettings.NotBeforeMinutes),
        //        Expires = DateTime.Now.AddMinutes(SiteSettings.JwtSettings.ExpirationMinutes),
        //        SigningCredentials = signingCredentials,
        //        EncryptingCredentials = encryptingCredentials,
        //        Subject = new ClaimsIdentity(claims)
        //    };

        //    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        //    JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
        //    JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);

        //    string encryptedJwt = tokenHandler.WriteToken(securityToken);

        //    return new AccessToken(securityToken);
        //}

        //private async Task<IEnumerable<Claim>> _getClaimsAsync(User user)
        //{
        //    var result = await SignInManager.ClaimsFactory.CreateAsync(user);

        //    var list = new List<Claim>(result.Claims);
        //    list.Add(new Claim(ClaimTypes.MobilePhone, "09123456987"));

        //    JwtRegisteredClaimNames.Sub
        //    var securityStampClaimType = new ClaimsIdentityOptions().SecurityStampClaimType;

        //    var list = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.UserName),
        //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //        //new Claim(ClaimTypes.MobilePhone, "09123456987"),
        //        //new Claim(securityStampClaimType, user.SecurityStamp.ToString())
        //    };

        //    var roles = new Role[] { new Role { Name = "Admin" } };
        //    foreach (var role in roles)
        //        list.Add(new Claim(ClaimTypes.Role, role.Name));

        //    return list;
        //}
    }
}
