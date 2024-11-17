namespace Application.Features.User.Commands.RemoveToken
{
    public class RemoveUserTokenCommand : IRequest
    {
        public string JwtToken { get; set; }
    }
}
