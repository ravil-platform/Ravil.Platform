namespace Application.Features.User.Commands.GenerateToken
{
    public class GenerateTokenCommand : IRequest<JsonResult>
    {
        public Guid UserId { get; set; }
    }
}