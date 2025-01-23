namespace Application.Features.Blog.Queries.GetById
{
    public class GetBlogByIdQuery : IRequest<BlogViewModel>
    {
        public int Id { get; set; }
    }
}
