namespace Application.Features.User.Queries.CheckIsJobBookMarked
{
    public class CheckIsJobBookMarkedQuery : IRequest<UserJobBookMarkViewModel>
    {
        public string JobBranchId { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
