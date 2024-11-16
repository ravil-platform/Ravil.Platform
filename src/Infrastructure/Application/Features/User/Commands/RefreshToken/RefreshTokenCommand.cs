namespace Application.Features.User.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<JsonResult>
    {
        public string RefreshToken { get; set; }
    }
}
