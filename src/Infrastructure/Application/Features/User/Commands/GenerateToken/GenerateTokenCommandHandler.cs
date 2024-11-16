using AngleSharp.Io;
using Constants.Security;
using UAParser;

namespace Application.Features.User.Commands.GenerateToken;

public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, JsonResult>
{
    protected IJwtService JwtService { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IHttpContextAccessor HttpContextAccessor { get; }

    public GenerateTokenCommandHandler(IJwtService jwtService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        JwtService = jwtService;
        UnitOfWork = unitOfWork;
        HttpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<JsonResult>> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.ApplicationUserRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            throw new NotFoundException();
        }

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

        await UnitOfWork.SaveAsync();

        return new JsonResult(token);
    }
}