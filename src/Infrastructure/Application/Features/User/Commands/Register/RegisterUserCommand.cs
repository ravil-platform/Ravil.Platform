namespace Application.Features.User.Commands.Register
{
    public class RegisterUserCommand : IRequest<RegisterUserResponseViewModel>
    {
        public string PhoneNumber { get; set; } = null!;

        public string? SmsCode { get; set; }
    }
}
