namespace Application.Features.User.Commands.RemoveToken;

public class RemoveUserTokenCommandHandler : IRequestHandler<RemoveUserTokenCommand>
{
    protected IUnitOfWork UnitOfWork { get; }

    public RemoveUserTokenCommandHandler(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveUserTokenCommand request, CancellationToken cancellationToken)
    {
        var result = new Result();

        var hashJwtToken = Security.GetSha256Hash(request.JwtToken);

        var userToken = await UnitOfWork.UserTokensRepository.GetByPredicate(u => u.HashJwtToken == hashJwtToken);

        if (userToken != null)
        {
            await UnitOfWork.UserTokensRepository.DeleteAsync(userToken);

            await UnitOfWork.SaveAsync();

            return result.WithSuccess("عملیات با موفقیت انجام شد");
        }

        return result.WithError(Resources.Messages.Validations.NotFoundException);
    }
}