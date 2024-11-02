namespace Application.Features.User.Commands.Create
{
    public class CreateUserCommand : IRequest<ApplicationUser>
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? NationalCode { get; set; }

        public string? Phone { get; set; }

        public GenderPerson Gender { get; set; }
    }
}
