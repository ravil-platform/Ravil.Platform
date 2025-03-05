using System.Text.Json;
using Application.Features.Blog.Queries.GetAllByFilter;
using Application.Features.Category.Queries.GetAllByFilter;
using Application.Features.Job.Queries.GetAllJobBranch;
using Application.Features.Job.Queries.GetRelatedJobBranches;
using Domain.Entities.FeedbackSlider;
using Domain.Entities.Order;
using Domain.Entities.RedirectionUrl;
using RNX.CustomResult;
using ViewModels.AdminPanel.Banner;
using ViewModels.AdminPanel.Category;
using ViewModels.AdminPanel.City;
using ViewModels.AdminPanel.Cms;
using ViewModels.AdminPanel.Cms.Blog;
using ViewModels.AdminPanel.Config;
using ViewModels.AdminPanel.FeedbackSlider;
using ViewModels.AdminPanel.MainSlider;
using ViewModels.AdminPanel.RedirectionUrl;
using ViewModels.Discounts;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
            CreateMap<Blog, BlogViewModel>()
                .ForMember(src => src.LikeCount, expression =>
                {
                    expression.PreCondition(a => a.BlogUserLikes.Any());
                    expression.MapFrom(a => a.BlogUserLikes.Count);
                })
                .ReverseMap();

            CreateMap<BlogCategory, BlogCategoryViewModel>().ReverseMap();

            CreateMap<Blog, CreateBlogViewModel>().ReverseMap();
            CreateMap<Blog, UpdateBlogViewModel>().ReverseMap();
            CreateMap<BlogCategory, CreateBlogCategoryViewModel>().ReverseMap();
            CreateMap<BlogCategory, UpdateBlogCategoryViewModel>().ReverseMap();

            #endregion

            #region ( Category )
            CreateMap<JobCategory, CategoryViewModel>()
                .ForMember(src => src.Id, expression => expression.MapFrom(a => a.Category.Id))
                .ForMember(src => src.Type, expression => expression.MapFrom(a => a.Category.Type))
                .ForMember(src => src.Sort, expression => expression.MapFrom(a => a.Category.Sort))
                .ForMember(src => src.Name, expression => expression.MapFrom(a => a.Category.Name))
                .ForMember(src => src.Route, expression => expression.MapFrom(a => a.Category.Route))
                .ForMember(src => src.ParentId, expression => expression.MapFrom(a => a.Category.ParentId))
                .ForMember(src => src.NodeLevel, expression => expression.MapFrom(a => a.Category.NodeLevel))
                .ForMember(src => src.IsLastNode, expression => expression.MapFrom(a => a.Category.IsLastNode))
                .ForMember(src => src.IsActive, expression => expression.MapFrom(a => a.Category.IsActive))
                .ForMember(src => src.Picture, expression => expression.MapFrom(a => a.Category.Picture))
                .ForMember(src => src.IconPicture, expression => expression.MapFrom(a => a.Category.IconPicture))
                .ForMember(src => src.PageContent, expression => expression.MapFrom(a => a.Category.PageContent))
                .ReverseMap();

            CreateMap<JobCategory, CategorySearchViewModel>()
                .ForMember(src => src.Id, expression => expression.MapFrom(a => a.Category.Id))
                .ForMember(src => src.Type, expression => expression.MapFrom(a => a.Category.Type))
                .ForMember(src => src.Name, expression => expression.MapFrom(a => a.Category.Name))
                .ForMember(src => src.Route, expression => expression.MapFrom(a => a.Category.Route))
                .ForMember(src => src.ParentId, expression => expression.MapFrom(a => a.Category.ParentId))
                .ForMember(src => src.NodeLevel, expression => expression.MapFrom(a => a.Category.NodeLevel))
                .ForMember(src => src.IsLastNode, expression => expression.MapFrom(a => a.Category.IsLastNode))
                .ReverseMap();


            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, MainCategories>().ReverseMap();
            CreateMap<CategoryService, CategoryServiceViewModel>().ReverseMap();

            CreateMap<Category, CreateCategoryViewModel>().ReverseMap();
            CreateMap<Category, UpdateCategoryViewModel>().ReverseMap();
            #endregion

            #region ( Job )
            CreateMap<Job, JobInfoViewModel>()
                /*.ForMember(src => src.WebSiteNames, expression =>
                {
                    expression.PreCondition(a => !string.IsNullOrWhiteSpace(a.WebSiteName));
                    expression.MapFrom(a => !string.IsNullOrWhiteSpace(a.WebSiteName) ? a.WebSiteName.Split(new[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries).ToList() : null);
                })
                .ForMember(src => src.Emails, expression =>
                {
                    expression.PreCondition(a => !string.IsNullOrWhiteSpace(a.Email));
                    expression.MapFrom(a => !string.IsNullOrWhiteSpace(a.Email) ? a.Email.Split(new[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries).ToList() : null);
                })*/
                .ForMember(src => src.PhoneNumberInfos, expression =>
                {
                    expression.PreCondition(a => !string.IsNullOrWhiteSpace(a.PhoneNumberInfos));
                    expression.PreCondition(a =>
                    {
                        if (string.IsNullOrWhiteSpace(a.PhoneNumberInfos)) return false;

                        var phoneNumberInfos =
                            JsonSerializer.Deserialize<List<PhoneNumberInfosViewModel>>(a.PhoneNumberInfos);

                        return phoneNumberInfos != null && phoneNumberInfos.All(current => !string.IsNullOrWhiteSpace(current.PhoneNumber));
                    });
                    expression.MapFrom(a => !string.IsNullOrWhiteSpace(a.PhoneNumberInfos) ? JsonConvert.DeserializeObject<List<PhoneNumberInfosViewModel>>(a.PhoneNumberInfos) : null);
                })
                .ForMember(src => src.SocialMediaInfos, expression =>
                {
                    expression.PreCondition(a => !string.IsNullOrWhiteSpace(a.SocialMediaInfos));
                    expression.PreCondition(a =>
                    {
                        if (string.IsNullOrWhiteSpace(a.SocialMediaInfos)) return false;

                        var socialMediaInfos =
                            JsonSerializer.Deserialize<List<SocialMediaInfosViewModel>>(a.SocialMediaInfos);

                        return socialMediaInfos != null && socialMediaInfos.All(current => !string.IsNullOrWhiteSpace(current.SocialMediaLink));

                    });
                    expression.MapFrom(a => !string.IsNullOrWhiteSpace(a.SocialMediaInfos) ? JsonConvert.DeserializeObject<List<SocialMediaInfosViewModel>>(a.SocialMediaInfos) : null);
                })
                .ReverseMap();

            CreateMap<Job, JobViewModel>()
                /*.ForMember(src => src.WebSiteName, expression =>
                {
                    expression.PreCondition(a => !string.IsNullOrWhiteSpace(a.WebSiteName));
                    expression.MapFrom(a => !string.IsNullOrWhiteSpace(a.WebSiteName) ? a.WebSiteName.Split(new[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries).ToList() : null);
                })
                .ForMember(src => src.Email, expression =>
                {
                    expression.PreCondition(a => !string.IsNullOrWhiteSpace(a.Email));
                    expression.MapFrom(a => !string.IsNullOrWhiteSpace(a.Email) ? a.Email.Split(new[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries).ToList() : null);
                })*/
                /*.ForMember(src => src.PhoneNumberInfos, expression => expression.Ignore())
                .ForMember(src => src.SocialMediaInfos, expression => expression.Ignore())*/
                .ForMember(src => src.PhoneNumberInfos, expression =>
                {
                    expression.PreCondition(a => !string.IsNullOrWhiteSpace(a.PhoneNumberInfos));
                    expression.PreCondition(a =>
                    {
                        if (string.IsNullOrWhiteSpace(a.PhoneNumberInfos)) return false;

                        var phoneNumberInfos =
                            JsonSerializer.Deserialize<List<PhoneNumberInfosViewModel>>(a.PhoneNumberInfos);

                        return phoneNumberInfos != null && phoneNumberInfos.All(current => !string.IsNullOrWhiteSpace(current.PhoneNumber));
                    });
                    expression.MapFrom(a => !string.IsNullOrWhiteSpace(a.PhoneNumberInfos) ? JsonConvert.DeserializeObject<List<PhoneNumberInfosViewModel>>(a.PhoneNumberInfos) : null);
                })
                .ForMember(src => src.SocialMediaInfos, expression =>
                {
                    expression.PreCondition(a => !string.IsNullOrWhiteSpace(a.SocialMediaInfos));
                    expression.PreCondition(a =>
                    {
                        if (string.IsNullOrWhiteSpace(a.SocialMediaInfos)) return false;

                        var socialMediaInfos =
                            JsonSerializer.Deserialize<List<SocialMediaInfosViewModel>>(a.SocialMediaInfos);

                        return socialMediaInfos != null && socialMediaInfos.All(current => !string.IsNullOrWhiteSpace(current.SocialMediaLink));

                    });
                    expression.MapFrom(a => !string.IsNullOrWhiteSpace(a.SocialMediaInfos) ? JsonConvert.DeserializeObject<List<SocialMediaInfosViewModel>>(a.SocialMediaInfos) : null);
                })
                .ReverseMap();

            CreateMap<Job, CreateJobCommand>().ReverseMap();
            CreateMap<Job, CreateJobViewModel>().ReverseMap();
            CreateMap<Job, UpdateJobCommand>().ReverseMap();
            
            CreateMap<Job, JobSearchResultViewModel>()
                .ForMember(src => src.Categories, expression =>
                {
                    expression.PreCondition(job => job is { JobCategories: not null } && job.JobCategories.Any(a => a.Category != null));
                    expression.MapFrom(job => job.JobCategories);
                })
                .ReverseMap();

            CreateMap<Job, ViewModels.AdminPanel.Job.CreateJobViewModel>().ReverseMap();
            CreateMap<Job, ViewModels.AdminPanel.Job.UpdateJobViewModel>().ReverseMap();
            CreateMap<JobBranch, ViewModels.AdminPanel.Job.CreateJobBranchViewModel>().ReverseMap();
            CreateMap<JobBranch, ViewModels.AdminPanel.Job.UpdateJobBranchViewModel>().ReverseMap();


            CreateMap<JobCategory, CreateJobCategoryCommand>().ReverseMap();
            CreateMap<JobCategory, UpdateJobCategoryCommand>().ReverseMap();

            CreateMap<JobBranch, UpdateJobBranchLocationCommand>().ReverseMap();
            CreateMap<JobBranch, JobBranchViewModel>()
                .ForMember(src => src.JobInfo, expression =>
                {
                    expression.MapFrom(a => a.Job);
                })
                .ForMember(src => src.Address, expression =>
                {
                    expression.MapFrom(a => a.Address);
                })
                .ForMember(src => src.Galleries, expression =>
                {
                    expression.MapFrom(a => a.JobBranchGalleries);
                })
                .ForMember(src => src.TimeWorks, expression =>
                {
                    expression.MapFrom(a => a.JobTimeWorks);
                })
                .ForMember(src => src.Categories, expression =>
                {
                    expression.PreCondition(a => a.Job is { JobCategories: not null } && a.Job.JobCategories.Any(a => a.Category != null));
                    expression.MapFrom(a => a.Job.JobCategories);
                })
                .ReverseMap();

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

            CreateMap<UserBookMark, UserJobBookMarkViewModel>().ReverseMap();
            CreateMap<UserBlogLike, UserBlogLikeViewModel>().ReverseMap();
            #endregion

            #region ( Service )
            CreateMap<Service, ServiceViewModel>().ReverseMap();
            #endregion

            #region ( Slider )
            CreateMap<MainSlider, MainSliderViewModel>()
                .ForMember(src => src.JobBranch, expression =>
                {
                    expression.MapFrom(a => a.JobBranch);
                })
                .ReverseMap();
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
            CreateMap<City, CityViewModel>()
                .ForMember(src => src.Route, expression => expression.MapFrom(a => a.CityBase.Name))
                .ReverseMap();

            CreateMap<CityCategoryViewModel, CityCategory>().ReverseMap();
            CreateMap<CityBaseViewModel, CityBase>().ReverseMap();

            CreateMap<CityBase, CityInfoViewModel>()
                .ForMember(src => src.StateBaseId, expression => expression.MapFrom(a => a.StateId))
                .ForMember(src => src.CityBaseId, expression => expression.MapFrom(a => a.Id))
                .ForMember(src => src.Subtitle, expression => expression.MapFrom(a => a.City.Subtitle))
                .ReverseMap();

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

            #region ( City )
            CreateMap<City, CreateCityViewModel>().ReverseMap();
            CreateMap<City, UpdateCityViewModel>().ReverseMap();
            #endregion

            #region ( Day Of Week )
            CreateMap<Domain.Entities.DayOfWeek.DayOfWeek, DayOfWeekViewModel>().ReverseMap();
            #endregion

            #region ( Location & Address )
            CreateMap<Location, LocationViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>()
                .ForMember(src => src.CityName, expression =>
                {
                    expression.PreCondition(a => a.City != null);
                    expression.MapFrom(a => a.City.Name);
                })
                .ForMember(src => src.Lat, expression =>
                {
                    expression.PreCondition(a => a.Location != null);
                    expression.MapFrom(a => a.Location.Lat);
                })
                .ForMember(src => src.Long, expression =>
                {
                    expression.PreCondition(a => a.Location != null);
                    expression.MapFrom(a => a.Location.Long);
                })
                .ReverseMap();
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
            CreateMap<FeedbackSlider, FeedbackSliderViewModel>().ReverseMap();
            #endregion

            #region ( Redirection Url )
            CreateMap<RedirectionUrl, CreateRedirectionUrlViewModel>().ReverseMap();
            CreateMap<RedirectionUrl, UpdateRedirectionUrlViewModel>().ReverseMap();
            #endregion

            #region ( Config )
            CreateMap<Config, AdminConfigViewModel>().ReverseMap();
            #endregion

            #region ( Discount )
            CreateMap<PromotionCode, CreateDiscountViewModel>().ReverseMap();
            CreateMap<PromotionCode, UpdateDiscountViewModel>().ReverseMap();
            #endregion

            CreateMap(typeof(CustomResult<>), typeof(Result<>)).ReverseMap();
        }
    }
}