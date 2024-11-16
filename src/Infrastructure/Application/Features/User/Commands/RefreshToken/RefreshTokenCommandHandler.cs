using AngleSharp.Io;
using Constants.Security;
using UAParser;

namespace Application.Features.User.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, JsonResult>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IHttpContextAccessor HttpContextAccessor { get; }
    protected IJwtService JwtService { get; }
    public RefreshTokenCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IJwtService jwtService)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
        HttpContextAccessor = httpContextAccessor;
        JwtService = jwtService;
    }

    public async Task<Result<JsonResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var hashRefreshToken = Security.GetSha256Hash(request.RefreshToken);

        var userToken = await UnitOfWork.UserTokensRepository
            .GetByPredicate(t => t.HashRefreshToken == hashRefreshToken);

        #region ( Token Validation )
        if (userToken is null)
        {
            throw new NotFoundException();
        }

        if (userToken.TokenExpireDate > DateTime.Now)
        {
            throw new BadRequestException("توکن منقضی نشده است");
        }

        if (userToken.RefreshTokenExpireDate < DateTime.Now)
        {
            throw new BadRequestException("زمان رفرش توکن منقضی شده است");
        }
        #endregion


        #region ( Remove User Token )
        var user = await UnitOfWork.ApplicationUserRepository.GetByIdAsync(userToken.UserId);

        await UnitOfWork.UserTokensRepository.DeleteUserTokenAsync(user.Id, userToken.Id);
        await UnitOfWork.SaveAsync();
        #endregion

        #region ( Refresh Token )
        var uaParser = Parser.GetDefault();
        var header = HttpContextAccessor.HttpContext.Request.Headers[HeaderNames.UserAgent].ToString();

        var device = "windows";
        if (header != null)
        {
            var info = uaParser.Parse(header);
            device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";
        }

        var token = await JwtService.GenerateAsync(user);

        await UnitOfWork.UserTokensRepository.InsertAsync(new UserTokens()
        {
            UserId = user.Id,
            HashJwtToken = Security.GetSha256Hash(token.access_token),
            HashRefreshToken = Security.GetSha256Hash(token.refresh_token),
            TokenExpireDate = DateTime.Now.AddDays(Jwt.TokenExpireDate),
            RefreshTokenExpireDate = DateTime.Now.AddDays(Jwt.RefreshTokenExpireDate),
            Device = device
        });
        #endregion

        await UnitOfWork.SaveAsync();

        return new JsonResult(token);
    }
}