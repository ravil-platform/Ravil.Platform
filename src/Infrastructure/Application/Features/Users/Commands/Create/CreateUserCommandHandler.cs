using AutoMapper;
using FluentResults;
using Persistence.Contracts;
using RNX.Mediator;
using System;

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApplicationUser>
{
    protected IValidator<CreateUserCommand> Validator { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateUserCommand> validator)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        Validator = validator;
    }
    public async Task<Result<ApplicationUser>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = Mapper.Map<ApplicationUser>(request);

        await UnitOfWork.ApplicationUserRepository.InsertAsync(user);

        await UnitOfWork.SaveAsync();

        return user;
    }
}