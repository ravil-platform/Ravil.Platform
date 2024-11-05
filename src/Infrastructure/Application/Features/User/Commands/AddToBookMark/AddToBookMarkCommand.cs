namespace Application.Features.User.Commands.AddToBookMark
{
    public class AddToBookMarkCommand : IRequest
    {
        public string UserId { get; set; } = null!;

        public int? BlogId { get; set; }
        public string? JobBranchId { get; set; }
        public string? UserIp { get; set; }

        public UserBookMarkType UserBookMarkType { get; set; }
    }
}