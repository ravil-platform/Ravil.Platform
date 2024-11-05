namespace Application.Features.User.Commands.UploadUserAvatar
{
    public class UploadUserAvatarCommand : IRequest
    {
        public string UserId { get; set; }
        public IFormFile Avatar { get; set; }
    }
}