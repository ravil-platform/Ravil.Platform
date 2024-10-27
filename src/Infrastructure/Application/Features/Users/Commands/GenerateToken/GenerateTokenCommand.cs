using RNX.Mediator;

namespace Application.Features.Users.Commands.GenerateToken
{
    public class GenerateTokenCommand : IRequest<JsonResult>
    {
        public Guid UserId { get; set; }
    }
}