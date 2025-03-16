namespace Application.Features.User.Commands.UpdateInfo
{
    public class UpdateUserInfoCommand : IRequest
    {
        public string Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        //public string Email { get; set; }

        public string NationalCode { get; set; }

        public GenderPerson Gender { get; set; }

        //public string Phone { get; set; }
        public string? BirthDate { get; set; }
    }
}
