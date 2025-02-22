namespace Application.Features.User.Queries.CheckIsBlogLiked;

public class CheckIsBlogLikedQueryHandler : IRequestHandler<CheckIsBlogLikedQuery, UserBlogLikeViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected UserManager<ApplicationUser> UserManager { get; }
        
    public CheckIsBlogLikedQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
        UserManager = userManager;
    }

    public async Task<Result<UserBlogLikeViewModel>> Handle(CheckIsBlogLikedQuery request, CancellationToken cancellationToken)
    {
        var blog = await UnitOfWork.BlogRepository.GetByPredicate(b => b.Id == request.BlogId, includes: nameof(UserBlogLike));

        if (blog is null)
        {
            var result = new UserBlogLikeViewModel();
            result.LikeCount = 0;
            result.IsLiked = false;

            return result;
        }
        if (blog is { BlogUserLikes: null })
        {
            var result = new UserBlogLikeViewModel();
            result.LikeCount = 0;
            result.IsLiked = false;

            return result;
        }

        var userBlogLike = blog.BlogUserLikes.SingleOrDefault(a => a.UserId.Equals(request.UserId));

        if (userBlogLike is not null)
        {
            var result = Mapper.Map<UserBlogLikeViewModel>(userBlogLike);
            result.LikeCount = blog.BlogUserLikes.Count;
            result.IsLiked = true;

            return result;
        }
        else
        {
            var result = new UserBlogLikeViewModel();
            result.LikeCount = 0;
            result.IsLiked = false;

            return result;
        }
    }
}