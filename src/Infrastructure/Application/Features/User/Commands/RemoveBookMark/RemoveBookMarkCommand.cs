namespace Application.Features.User.Commands.RemoveBookMark
{
    public class RemoveBookMarkCommand : IRequest
    {
        public string UserId { get; set; }
        public string JobBranchId { get; set; }
    }
}
