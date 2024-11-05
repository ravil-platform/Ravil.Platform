namespace Application.Features.User.Queries.GetUserJobBranches
{
    public class GetUserJobBranchesQuery : IRequest<List<UserJobBranchesViewModel>>
    {
        public string UserId { get; set; }
    }
}
