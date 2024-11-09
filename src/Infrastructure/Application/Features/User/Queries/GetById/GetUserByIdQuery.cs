namespace Application.Features.User.Queries.GetById
{
    public class GetUserByIdQuery : IRequest<ApplicationUserViewModel>
    {
        public string Id { get; set; } = null!;
    }
}
