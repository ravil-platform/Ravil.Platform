using Application.Contracts.Identity;
using FluentResults;
using Persistence.Contracts;
using RNX.Mediator;

namespace Application.Features.Users.Commands.GenerateToken;

public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, JsonResult>
{
    protected IJwtService JwtService { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GenerateTokenCommandHandler(IUnitOfWork unitOfWork, IJwtService jwtService)
    {
        UnitOfWork = unitOfWork;
        JwtService = jwtService;
    }

    public async Task<Result<JsonResult>> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.ApplicationUserRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            throw new Exception();
        }

        var jwt = await JwtService.GenerateAsync(user);

        return new JsonResult(jwt);
    }
}