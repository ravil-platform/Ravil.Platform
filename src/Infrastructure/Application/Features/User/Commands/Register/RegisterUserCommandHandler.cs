namespace Application.Features.User.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
{
    protected IUnitOfWork UnitOfWork { get; }

    public RegisterUserCommandHandler(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
    public async Task<Result<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {

        var currentUser = await UnitOfWork.ApplicationUserRepository
            .GetByPredicate(u => u.Phone == request.PhoneNumber);

        if (request.SmsCode == null)
        {
            if (currentUser is not null)
            {
                //user exist before
                //Send Sms Code and login
            }

            //Register User And Send Sms Code

            var user = new ApplicationUser()
            {
                PhoneNumber = request.PhoneNumber,
                PhoneNumberConfirmed = false,
                RegisterDate = DateTime.Now,
                UserName = request.PhoneNumber,
                Firstname = "کاربر",
                Lastname = "سایت",
                UserNameType = UserNameType.PhoneNumber,
                Gender = GenderPerson.Other,
            };

            await UnitOfWork.ApplicationUserRepository.InsertAsync(user);
            await UnitOfWork.SaveAsync();

            //send sms code and go for login

            return user.Id;
        }
        else
        {
            return "empty";
        }
    }
}