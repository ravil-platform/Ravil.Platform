using RNX.Mediator;

namespace Application.Features.User.Commands.Register
{
    public class RegisterUserCommand : IRequest<string>
    {
        public string PhoneNumber { get; set; } = null!;

        public string SmsCode { get; set; }
    }
}
