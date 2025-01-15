using Application.Features.Blog.Queries.GetAllByFilter;
using Application.Features.Category.Queries.GetAllByFilter;
using Application.Features.Job.Queries.GetAllJobBranch;
using Application.Features.Job.Queries.GetRelatedJobBranches;
using Domain.Entities.FeedbackSlider;
using Domain.Entities.RedirectionUrl;
using RNX.CustomResult;
using ViewModels.AdminPanel.Banner;
using ViewModels.AdminPanel.Category;
using ViewModels.AdminPanel.Cms;
using ViewModels.AdminPanel.Cms.Blog;
using ViewModels.AdminPanel.Config;
using ViewModels.AdminPanel.FeedbackSlider;
using ViewModels.AdminPanel.MainSlider;
using ViewModels.AdminPanel.RedirectionUrl;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base()
        {
            #region ( Users )
            CreateMap<ApplicationUser, CreateUserViewModel>().ReverseMap();
            CreateMap<ApplicationUser, CreateUserCommand>().ReverseMap();

            CreateMap<ApplicationUser, UpdateUserViewModel>().ReverseMap();
            CreateMap<ApplicationUser, UpdateUserInfoCommand>().ReverseMap();

            CreateMap<ApplicationUser, RegisterOrLoginUserCommand>().ReverseMap();
            CreateMap<ApplicationUser, RegisterOrLoginUserResponseViewModel>().ReverseMap();

            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();

            CreateMap<AddToBookMarkCommand, UserBookMark>().ReverseMap();
            CreateMap<AddBlogLikeCommand, UserBlogLike>().ReverseMap();
            #endregion

            #region ( Faqs )
            CreateMap<Faq, CreateFaqViewModel>().ReverseMap();
            CreateMap<Faq, UpdateFaqViewModel>().ReverseMap();
            CreateMap<Faq, FaqViewModel>().ReverseMap();

            CreateMap<FaqCategory, CreateFaqCategoryViewModel>().ReverseMap();
            CreateMap<FaqCategory, UpdateFaqCategoryViewModel>().ReverseMap();
            CreateMap<FaqCategory, FaqCategoryViewModel>().ReverseMap();
            #endregion

            #region ( Blog )
            CreateMap<Blog, BlogViewModel>().ReverseMap();
            CreateMap<BlogCategory, BlogCategoryViewModel>().ReverseMap();

            CreateMap<Blog, CreateBlogViewModel>().ReverseMap();
            CreateMap<Blog, UpdateBlogViewModel>().ReverseMap();
            CreateMap<BlogCategory, CreateBlogCategoryViewModel>().ReverseMap();
            CreateMap<BlogCategory, UpdateBlogCategoryViewModel>().ReverseMap();

            #endregion

            #region ( Category )
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, MainCategories>().ReverseMap();
            CreateMap<CategoryService, CategoryServiceViewModel>().ReverseMap();

            CreateMap<Category, CreateCategoryViewModel>().ReverseMap();
            CreateMap<Category, UpdateCategoryViewModel>().ReverseMap();
            #endregion

            #region ( Job )
            CreateMap<Job, JobViewModel>().ReverseMap();
            CreateMap<Job, CreateJobCommand>().ReverseMap();
            CreateMap<Job, CreateJobViewModel>().ReverseMap();
            CreateMap<Job, UpdateJobCommand>().ReverseMap();

            CreateMap<Job, ViewModels.AdminPanel.Job.CreateJobViewModel>().ReverseMap();
            CreateMap<Job, ViewModels.AdminPanel.Job.UpdateJobViewModel>().ReverseMap();
            CreateMap<JobBranch, ViewModels.AdminPanel.Job.CreateJobBranchViewModel>().ReverseMap();
            CreateMap<JobBranch, ViewModels.AdminPanel.Job.UpdateJobBranchViewModel>().ReverseMap();


            CreateMap<JobCategory, CreateJobCategoryCommand>().ReverseMap();
            CreateMap<JobCategory, UpdateJobCategoryCommand>().ReverseMap();

            CreateMap<JobBranch, UpdateJobBranchLocationCommand>().ReverseMap();
            CreateMap<JobBranch, JobBranchViewModel>().ReverseMap();
            CreateMap<JobBranch, CreateJobBranchViewModel>().ReverseMap();
            CreateMap<JobBranch, CreateJobBranchCommand>().ReverseMap();
            CreateMap<JobBranch, UpdateJobBranchViewModel>().ReverseMap();

            CreateMap<JobBranchTag, JobBranchTagViewModel>().ReverseMap();

            CreateMap<JobService, JobServiceViewModel>().ReverseMap();
            CreateMap<JobSelectionSliderViewModel, JobSelectionSlider>().ReverseMap();
            CreateMap<JobTimeWork, JobTimeWorkViewModel>().ReverseMap();

            CreateMap<JobCategoriesView, JobCategory>().ReverseMap();

            CreateMap<JobBranchShortLink, JobBranchShortLinkViewModel>().ReverseMap();
            CreateMap<JobBranchGalleryViewModel, JobBranchGallery>().ReverseMap();
            #endregion

            #region ( Service )
            CreateMap<Service, ServiceViewModel>().ReverseMap();
            #endregion

            #region ( Slider )
            CreateMap<MainSlider, MainSliderViewModel>().ReverseMap();
            CreateMap<MainSlider, CreateMainSliderViewModel>().ReverseMap();
            CreateMap<MainSlider, UpdateMainSliderViewModel>().ReverseMap();
            #endregion

            #region ( Short Link )
            CreateMap<ShortLink, ShortLinkViewModel>().ReverseMap();
            #endregion

            #region ( Tag )
            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<BlogTag, BlogTagViewModel>().ReverseMap();
            CreateMap<Tag, CreateTagViewModel>().ReverseMap();
            CreateMap<Tag, UpdateTagViewModel>().ReverseMap();
            CreateMap<JobTag, JobTagViewModel>().ReverseMap();
            #endregion

            #region ( City & City Base & State )
            CreateMap<City, CityViewModel>().ReverseMap();
            CreateMap<CityCategoryViewModel, CityCategory>().ReverseMap();
            CreateMap<CityBaseViewModel, CityBase>().ReverseMap();

            CreateMap<State, StateViewModel>().ReverseMap();
            CreateMap<StateBase, StateBaseViewModel>().ReverseMap();
            #endregion

            #region ( Team )
            CreateMap<Team, TeamViewModel>().ReverseMap();
            #endregion

            #region ( Banner )
            CreateMap<Banner, BannerViewModel>().ReverseMap();
            CreateMap<Banner, CreateBannerViewModel>().ReverseMap();
            CreateMap<Banner, UpdateBannerViewModel>().ReverseMap();
            #endregion

            #region ( Brand )
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            #endregion

            #region ( Comment )
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Comment, CreateCommentCommand>().ReverseMap();

            CreateMap<AnswerComment, CreateAnswerCommentCommand>().ReverseMap();
            CreateMap<AnswerComment, AnswerCommentViewModel>().ReverseMap();
            #endregion

            #region ( Config )
            CreateMap<Config, ConfigViewModel>().ReverseMap();
            #endregion

            #region ( Day Of Week )
            CreateMap<Domain.Entities.DayOfWeek.DayOfWeek, DayOfWeekViewModel>().ReverseMap();
            #endregion

            #region ( Location & Address )
            CreateMap<Location, LocationViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            #endregion

            #region ( Filters )
            CreateMap<JobBranchFilter, GetAllJobBranchByFilterQuery>().ReverseMap();
            CreateMap<JobBranchFilter, GetRelatedJobBranchesQuery>().ReverseMap();

            CreateMap<BlogFilterViewModel, GetAllBlogsByFilterQuery>().ReverseMap();

            CreateMap<CategoryFilterViewModel, GetAllCategoriesByFilterQuery>().ReverseMap();
            #endregion

            #region ( FeedbakSlider )
            CreateMap<FeedbackSlider, CreateFeedbackSliderViewModel>().ReverseMap();
            CreateMap<FeedbackSlider, UpdateFeedbackSliderViewModel>().ReverseMap();
            #endregion

            #region ( Redirection Url )
            CreateMap<RedirectionUrl, CreateRedirectionUrlViewModel>().ReverseMap();
            CreateMap<RedirectionUrl, UpdateRedirectionUrlViewModel>().ReverseMap();
            #endregion

            #region ( Config )
            CreateMap<Config, AdminConfigViewModel>().ReverseMap();
            #endregion

            CreateMap(typeof(CustomResult<>), typeof(Result<>)).ReverseMap();
        }
    }
}