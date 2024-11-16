namespace Application.Features.User.Commands.RegisterOrLogin
{
    public class RegisterOrLoginUserCommand : IRequest<RegisterOrLoginUserResponseViewModel>
    {
        public string PhoneNumber { get; set; } = null!;
        public string? SmsCode { get; set; }
    }
}
