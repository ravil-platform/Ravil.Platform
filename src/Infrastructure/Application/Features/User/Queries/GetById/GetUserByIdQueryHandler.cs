namespace Application.Features.User.Queries.GetById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ApplicationUserViewModel>
{
    protected IMapper Mapper { get; }
    protected UserManager<ApplicationUser> UserManager { get; }

    public GetUserByIdQueryHandler(IMapper mapper,UserManager<ApplicationUser> userManager)
    {
        Mapper = mapper;
        UserManager = userManager;
    }

    public async Task<Result<ApplicationUserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await UserManager.FindByIdAsync(request.Id);

        if (user is null)
        {
            throw new NotFoundException();
        }

        var result = Mapper.Map<ApplicationUserViewModel>(user);

        return result;
    }
}