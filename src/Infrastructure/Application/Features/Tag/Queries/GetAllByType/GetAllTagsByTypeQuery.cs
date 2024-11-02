namespace Application.Features.Tag.Queries.GetAllByType
{
    public class GetAllTagsByTypeQuery : IRequest<List<TagViewModel>>
    {
        public TagType Type { get; set; }
    }
}