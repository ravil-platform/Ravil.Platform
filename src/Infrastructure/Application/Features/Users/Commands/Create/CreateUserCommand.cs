using Domain.Entities.User.Enums;
using RNX.Mediator;

namespace Application.Features.Users.Commands.Create
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
