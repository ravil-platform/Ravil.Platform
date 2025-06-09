using Domain.Entities.Wallets;
using ViewModels.AdminPanel.Comment;
using ViewModels.AdminPanel.PanelTutorial;
using ViewModels.QueriesResponseViewModel.Wallet;
using ViewModels.QueriesResponseViewModel.Payments;
using CreateJobViewModel = ViewModels.QueriesResponseViewModel.Job.CreateJobViewModel;
using CreateJobBranchViewModel = ViewModels.QueriesResponseViewModel.Job.CreateJobBranchViewModel;
using UpdateJobBranchViewModel = ViewModels.QueriesResponseViewModel.Job.UpdateJobBranchViewModel;

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

            CreateMap<ApplicationUser, RegisterOrLoginUserCommand>()
                .ForMember(dest => dest.SmsCode, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ApplicationUser, RegisterOrLoginUserResponseViewModel>().ReverseMap();

            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dest => dest.UserSubscriptionPlan, expression =>
                {
                    expression.Condition(a => a.UserSubscriptions != null);
                    expression.MapFrom(a => a.UserSubscriptions.FirstOrDefault(s => s.IsActive && s.IsFinally && s.EndDate.Day >= DateTime.UtcNow.Day));
                })
                .ForMember(dest => dest.Wallet, expression =>
                {
                    expression.Condition(a => a.Wallet != null);
                    expression.MapFrom(a => a.Wallet);
                })
                .ReverseMap();

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
            CreateMap<JobCategory, CategoryListViewModel>()
                .ForMember(src => src.Id, expression => expression.MapFrom(a => a.Category.Id))
                .ForMember(src => src.Type, expression => expression.MapFrom(a => a.Category.Type))
                .ForMember(src => src.Sort, expression => expression.MapFrom(a => a.Category.Sort))
                .ForMember(src => src.Name, expression => expression.MapFrom(a => a.Category.Name))
                .ForMember(src => src.Route, expression => expression.MapFrom(a => !a.Category.Route.Contains("-") ? a.Category.Route.Trim().Replace(' ', '-') : a.Category.Route))
                .ForMember(src => src.ParentId, expression => expression.MapFrom(a => a.Category.ParentId))
                .ForMember(src => src.NodeLevel, expression => expression.MapFrom(a => a.Category.NodeLevel))
                .ForMember(src => src.IsLastNode, expression => expression.MapFrom(a => a.Category.IsLastNode))
                .ForMember(src => src.IsActive, expression => expression.MapFrom(a => a.Category.IsActive))
                .ForMember(src => src.Picture, expression => expression.MapFrom(a => a.Category.Picture))
                .ForMember(src => src.IconPicture, expression => expression.MapFrom(a => a.Category.IconPicture))
                //.ForMember(src => src.PageContent, expression => expression.MapFrom(a => a.Category.PageContent))
                .ReverseMap();

            CreateMap<JobCategory, CategoryViewModel>()
                .ForMember(src => src.Id, expression => expression.MapFrom(a => a.Category.Id))
                .ForMember(src => src.Type, expression => expression.MapFrom(a => a.Category.Type))
                .ForMember(src => src.Sort, expression => expression.MapFrom(a => a.Category.Sort))
                .ForMember(src => src.Name, expression => expression.MapFrom(a => a.Category.Name))
                .ForMember(src => src.Route, expression => expression.MapFrom(a => !a.Category.Route.Contains("-") ? a.Category.Route.Trim().Replace(' ', '-') : a.Category.Route))
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
                .ForMember(src => src.Route, expression => expression.MapFrom(a => !a.Category.Route.Contains("-") ? a.Category.Route.Trim().Replace(' ', '-') : a.Category.Route))
                .ForMember(src => src.ParentId, expression => expression.MapFrom(a => a.Category.ParentId))
                .ForMember(src => src.NodeLevel, expression => expression.MapFrom(a => a.Category.NodeLevel))
                .ForMember(src => src.IsLastNode, expression => expression.MapFrom(a => a.Category.IsLastNode))
                .ReverseMap();


            CreateMap<CategoryService, CategoryServiceViewModel>().ReverseMap();
            CreateMap<Category, CategoryListViewModel>()
                .ForMember(src => src.Route, expression => expression.MapFrom(a =>
                    !a.Route.Contains("-") ? a.Route.Trim().Replace(' ', '-') : a.Route))
                .ReverseMap();

            CreateMap<Category, CategoryViewModel>()
                .ForMember(src => src.KeywordId, expression => expression.MapFrom(a => a.Keywords.FirstOrDefault(s => s.IsCategory)!.Id))
                .ForMember(src => src.Route, expression => expression.MapFrom(a =>
                    !a.Route.Contains("-") ? a.Route.Trim().Replace(' ', '-') : a.Route))
                .ReverseMap();

            CreateMap<Category, MainCategories>()
                .ForMember(src => src.Route, expression => expression.MapFrom(a =>
                    !a.Route.Contains("-") ? a.Route.Trim().Replace(' ', '-') : a.Route))
                .ReverseMap();

            CreateMap<Category, CreateCategoryViewModel>().ReverseMap();
            CreateMap<Category, UpdateCategoryViewModel>().ReverseMap();
            #endregion

            #region ( ActionHistories )

            CreateMap<ActionHistories, CreateActionHistoriesCommandData>()
                .ReverseMap()
                //.ForMember(src => src.Id, expression => expression.MapFrom(a => Guid.NewGuid()))
                .ForMember(src => src.PageUrl, expression => expression.MapFrom(a => WebUtility.UrlDecode(a.PageUrl)))
                .ForMember(src => src.PageSlug, expression => expression.MapFrom(a => WebUtility.UrlDecode(a.PageSlug)))
                .ForMember(src => src.PageTitle, expression => expression.MapFrom(a => WebUtility.UrlDecode(a.PageTitle)));

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
                    expression.Condition(a => !string.IsNullOrWhiteSpace(a.PhoneNumberInfos));
                    expression.Condition(a =>
                    {
                        if (string.IsNullOrWhiteSpace(a.PhoneNumberInfos)) return false;

                        var phoneNumberInfos =
                            System.Text.Json.JsonSerializer.Deserialize<List<ViewModels.QueriesResponseViewModel.Job.PhoneNumberInfosViewModel>>(a.PhoneNumberInfos);

                        return phoneNumberInfos != null && phoneNumberInfos.All(current => !string.IsNullOrWhiteSpace(current.PhoneNumber));
                    });
                    expression.MapFrom(a => !string.IsNullOrWhiteSpace(a.PhoneNumberInfos) ? JsonConvert.DeserializeObject<List<ViewModels.QueriesResponseViewModel.Job.PhoneNumberInfosViewModel>>(a.PhoneNumberInfos) : null);
                })
                .ForMember(src => src.SocialMediaInfos, expression =>
                {
                    expression.Condition(a => !string.IsNullOrWhiteSpace(a.SocialMediaInfos));
                    expression.Condition(a =>
                    {
                        if (string.IsNullOrWhiteSpace(a.SocialMediaInfos)) return false;

                        var socialMediaInfos =
                            System.Text.Json.JsonSerializer.Deserialize<List<ViewModels.QueriesResponseViewModel.Job.SocialMediaInfosViewModel>>(a.SocialMediaInfos);

                        return socialMediaInfos != null && socialMediaInfos.All(current => !string.IsNullOrWhiteSpace(current.SocialMediaLink));

                    });
                    expression.MapFrom(a => !string.IsNullOrWhiteSpace(a.SocialMediaInfos) ? JsonConvert.DeserializeObject<List<ViewModels.QueriesResponseViewModel.Job.SocialMediaInfosViewModel>>(a.SocialMediaInfos) : null);
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
                            System.Text.Json.JsonSerializer.Deserialize<List<ViewModels.QueriesResponseViewModel.Job.PhoneNumberInfosViewModel>>(a.PhoneNumberInfos);

                        return phoneNumberInfos != null && phoneNumberInfos.All(current => !string.IsNullOrWhiteSpace(current.PhoneNumber));
                    });
                    expression.MapFrom(a => System.Text.Json.JsonSerializer.Deserialize<List<ViewModels.QueriesResponseViewModel.Job.PhoneNumberInfosViewModel>>(a.PhoneNumberInfos, JsonSerializerOptions.Web));
                })
                .ForMember(src => src.SocialMediaInfos, expression =>
                {
                    expression.PreCondition(a => !string.IsNullOrWhiteSpace(a.SocialMediaInfos));
                    expression.PreCondition(a =>
                    {
                        if (string.IsNullOrWhiteSpace(a.SocialMediaInfos)) return false;

                        var socialMediaInfos =
                            System.Text.Json.JsonSerializer.Deserialize<List<ViewModels.QueriesResponseViewModel.Job.SocialMediaInfosViewModel>>(a.SocialMediaInfos);

                        return socialMediaInfos != null && socialMediaInfos.All(current => !string.IsNullOrWhiteSpace(current.SocialMediaLink));

                    });
                    expression.MapFrom(a => System.Text.Json.JsonSerializer.Deserialize<List<ViewModels.QueriesResponseViewModel.Job.SocialMediaInfosViewModel>>(a.SocialMediaInfos, JsonSerializerOptions.Web));
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

            #region ( UpdateBusinessCommand )

            CreateMap<UpdateBusinessCommand, JobBranch>()
                .ForMember(src => src.Description, expression => expression.MapFrom(a => a.Summary))
                .ForMember(src => src.BranchContent, expression => expression.MapFrom(a => a.Description))
                .ReverseMap();

            CreateMap<UpdateBusinessCommand, Address>()
                //.ForMember(src => src.Location.Lat, expression => expression.MapFrom(a => a.Lat))
                //.ForMember(src => src.Location.Long, expression => expression.MapFrom(a => a.Long))
                .ForMember(src => src.PostalAddress, expression => expression.MapFrom(a => a.FullAddress))
                .ReverseMap();

            CreateMap<UpdateBusinessCommand, Location>()
                .ForMember(src => src.Lat, expression => expression.MapFrom(a => a.Lat))
                .ForMember(src => src.Long, expression => expression.MapFrom(a => a.Long))
                .ReverseMap();

            #endregion

            #region ( GuideLine )

            CreateMap<JobBranch, GuideLineCompletionViewModel>()
                .ForMember(src => src.Business, expression =>
                {
                    expression.MapFrom(a => a);
                })
                .ReverseMap();

            CreateMap<GuideLineCompletionCommand, Job>()
                .ReverseMap();

            CreateMap<GuideLineCompletionCommand, JobBranch>()
                .ForMember(src => src.Description, expression => expression.MapFrom(a => a.Summary))
                .ForMember(src => src.BranchContent, expression => expression.MapFrom(a => a.Description))
                .ReverseMap();

            CreateMap<GuideLineCompletionCommand, Address>()
                .ForMember(src => src.PostalAddress, expression => expression.MapFrom(a => a.FullAddress))
                .ReverseMap()
                .ForMember(src => src.Lat, expression => expression.MapFrom(a => a.Location.Lat))
                .ForMember(src => src.Long, expression => expression.MapFrom(a => a.Location.Long));

            CreateMap<GuideLineCompletionCommand, Location>()
                .ForMember(src => src.Lat, expression => expression.MapFrom(a => a.Lat))
                .ForMember(src => src.Long, expression => expression.MapFrom(a => a.Long))
                .ReverseMap();

            #endregion

            #region ( Keyword )

            CreateMap<Category, Keyword>()
                .ForMember(src => src.Id, expression => expression.Ignore())
                .ForMember(src => src.Slug, expression => expression.MapFrom(a => a.Route))
                .ForMember(src => src.Title, expression => expression.MapFrom(a => a.Name))
                .ForMember(src => src.CategoryId, expression => expression.MapFrom(a => a.Id))
                .ReverseMap();

            CreateMap<Keyword, JobKeywordViewModel>().ReverseMap();
            CreateMap<JobKeyword, KeywordViewModel>()
                .ForMember(src => src.Id, expression => expression.MapFrom(a => a.Keyword.Id))
                .ForMember(src => src.Slug, expression => expression.MapFrom(a => a.Keyword.Slug))
                .ForMember(src => src.Title, expression => expression.MapFrom(a => a.Keyword.Title))
                .ForMember(src => src.IsActive, expression => expression.MapFrom(a => a.Keyword.IsActive))
                .ForMember(src => src.IsCategory, expression => expression.MapFrom(a => a.Keyword.IsCategory))
                .ForMember(src => src.CategoryId, expression => expression.MapFrom(a => a.Keyword.CategoryId))
                .ReverseMap()
                .ForMember(src => src.Keyword, expression =>
                {
                    expression.MapFrom(a => a);
                });

            CreateMap<Keyword, JobTagsViewModel>().ReverseMap();
            CreateMap<Keyword, KeywordViewModel>()
                .ForMember(src => src.Category, expression =>
                {
                    expression.MapFrom(a => a.Category);
                })
                .ReverseMap();

            #endregion

            #region ( JobRankingHistory )

            CreateMap<JobRankingHistory, AddJobRankingCommandData>()
                .ReverseMap()
                //.ForMember(src => src.Id, expression => expression.MapFrom(a => Guid.NewGuid()))
                .ForMember(src => src.PageUrl, expression => expression.MapFrom(a => WebUtility.UrlDecode(a.PageUrl)))
                .ForMember(src => src.CreateAt, expression => expression.MapFrom(a => DateTime.UtcNow));

            CreateMap<JobInfo, JobStatisticsViewModel>().ReverseMap();

            #endregion

            CreateMap<JobBranch, UpdateJobBranchLocationCommand>().ReverseMap();
            CreateMap<JobBranch, JobBranchViewModel>()
                .ForMember(src => src.JobInfo, expression =>
                {
                    expression.MapFrom(a => a.Job);
                })
                .ForPath(src => src.JobInfo.PhoneNumberInfos, expression =>
                {
                    expression.MapFrom(a => JsonConvert.DeserializeObject<List<ViewModels.QueriesResponseViewModel.Job.PhoneNumberInfosViewModel>>(a.Job.PhoneNumberInfos));
                })
                .ForPath(src => src.JobInfo.SocialMediaInfos, expression =>
                {
                    expression.MapFrom(a => JsonConvert.DeserializeObject<List<ViewModels.QueriesResponseViewModel.Job.SocialMediaInfosViewModel>>(a.Job.SocialMediaInfos));
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
                .ForMember(src => src.Keywords, expression =>
                {
                    expression.Condition(a => a.JobKeywords != null && a.JobKeywords.Any());
                    expression.MapFrom(a => a.JobKeywords.Select(s => s.Keyword));
                })
                /*.ForMember(src => src.IsAds, expression =>
                {
                    expression.Condition(a => a.ApplicationUser?.UserSubscriptions.Where(s => s is { IsActive: true, IsFinally: true } && s.EndDate.Day >= DateTime.UtcNow.Day) != null);
                    expression.MapFrom(dest => dest.ApplicationUser.UserSubscriptions.SingleOrDefault(s => s.IsActive && s.IsFinally && s.EndDate.Day >= DateTime.UtcNow.Day) != null);
                })*/
                /*.ForMember(src => src.SubscriptionType, expression =>
                {
                    expression.Condition(a => a.ApplicationUser?.UserSubscriptions.Where(s => s is { IsActive: true, IsFinally: true } && s.EndDate.Day >= DateTime.UtcNow.Day && s.Subscription != null) != null);
                    expression.MapFrom(dest => dest.ApplicationUser.UserSubscriptions.Where(s => s.IsActive && s.IsFinally && s.EndDate.Day >= DateTime.UtcNow.Day && s.Subscription != null).Select(a => a.Subscription.Type).SingleOrDefault());
                })*/
                .ForMember(src => src.Categories, expression =>
                {
                    expression.PreCondition(a => a.Job is { JobCategories: not null } && a.Job.JobCategories.Any(a => a.Category != null));
                    expression.MapFrom(a => a.Job.JobCategories);
                })
                .ReverseMap();

            CreateMap<JobBranch, UserJobBranchesViewModel>()
                .ForMember(src => src.CommentCount, expression =>
                {
                    expression.MapFrom(a => a.Comments!.Count);
                })
                .ForMember(src => src.BookMarkCount, expression =>
                {
                    expression.MapFrom(a => a.JobUserBookMarks!.Count(j => j.UserBookMarkType == UserBookMarkType.JobBranch));
                })
                .ForMember(src => src.JobInfo, expression =>
                {
                    expression.MapFrom(a => a.Job);
                })
                .ForPath(src => src.JobInfo.PhoneNumberInfos, expression =>
                {
                    expression.MapFrom(a => System.Text.Json.JsonSerializer.Deserialize<List<ViewModels.QueriesResponseViewModel.Job.PhoneNumberInfosViewModel>>(a.Job.PhoneNumberInfos, JsonSerializerOptions.Web));
                })
                .ForPath(src => src.JobInfo.SocialMediaInfos, expression =>
                {
                    expression.MapFrom(a => System.Text.Json.JsonSerializer.Deserialize<List<ViewModels.QueriesResponseViewModel.Job.SocialMediaInfosViewModel>>(a.Job.SocialMediaInfos, JsonSerializerOptions.Web));
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


            CreateMap<Keyword, CreateKeywordViewModel>().ReverseMap();
            CreateMap<Keyword, UpdateKeywordViewModel>().ReverseMap();
            
            CreateMap<ClickAdsSetting, SetAdsClickSettingCommand>().ReverseMap();
            CreateMap<ClickAdsSetting, ClickAdsSettingViewModel>().ReverseMap();
            #endregion

            #region ( MessageBox )

            CreateMap<MessageBox, MessageBoxViewModel>()
                .ForMember(src => src.Type, expression => expression.MapFrom(a => a.Type.GetEnumDisplayName()))
                .ReverseMap();

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

            #region ( MessageBox )
            CreateMap<MessageBox, CreateMessageBoxViewModel>().ReverseMap();
            CreateMap<MessageBox, UpdateMessageBoxViewModel>().ReverseMap();
            #endregion

            #region ( Short Link )
            CreateMap<ShortLink, ShortLinkViewModel>().ReverseMap();
            #endregion

            #region ( Subscription )

            CreateMap<CreateSubscriptionViewModel, Subscription>().ReverseMap();
            CreateMap<UpdateSubscriptionViewModel, Subscription>().ReverseMap();

            CreateMap<UpdateFeatureViewModel, Feature>().ReverseMap();
            CreateMap<CreateFeatureViewModel, Feature>().ReverseMap();


            CreateMap<SubscriptionFeature, SubscriptionFeatureViewModel>()
                .ForMember(src => src.FeatureId, expression => expression.MapFrom(a => a.FeatureId))
                .ForMember(src => src.FeatureIcon, expression => expression.MapFrom(a => a.Feature.Icon))
                .ForMember(src => src.FeatureTitle, expression => expression.MapFrom(a => a.Feature.Title))
                .ReverseMap();

            CreateMap<Subscription, SubscriptionViewModel>()
                .ForMember(src => src.Features, expression =>
                {
                    expression.MapFrom(a => a.SubscriptionFeatures);
                })
                .ReverseMap();

            CreateMap<UserSubscription, UserSubscriptionViewModel>()
            .ForMember(src => src.Subscription, expression =>
            {
                expression.MapFrom(a => a.Subscription);
            })
            .ReverseMap();

            #region ( Subscription Click )

            CreateMap<SubscriptionClick, AdsClickActivityCommand>()
                .ForMember(src => src.KeywordSlug, expression => expression.MapFrom(a => WebUtility.UrlDecode(a.KeywordSlug)))
                .ForMember(src => src.KeywordPageUrl, expression => expression.MapFrom(a => WebUtility.UrlDecode(a.KeywordPageUrl)))
                .ForMember(src => src.KeywordPageTitle, expression => expression.MapFrom(a => WebUtility.UrlDecode(a.KeywordPageTitle)))
                .ReverseMap()
                .ForMember(src => src.Subscription, expression => expression.Ignore())
                .ForMember(src => src.Click, expression => expression.Ignore())
                .ForMember(src => src.Job, expression => expression.Ignore());

            CreateMap<SubscriptionClick, SubscriptionClickViewModel>()
                .ForMember(src => src.ClickedTimeStamp, expression => expression.MapFrom(a => new DateTimeOffset(a.ClickedTime).ToUnixTimeSeconds()))
                .ForMember(src => src.ClickTitle, expression => expression.MapFrom(a => a.Click.Title))
                .ForMember(src => src.ClickType, expression => expression.MapFrom(a => a.Click.Type))
                .ReverseMap();

            #endregion

            #endregion

            #region ( PanelTutorial )
            CreateMap<PanelTutorial, PanelTutorialViewModel>()
                .ForMember(src => src.Time, expression => expression.MapFrom(a => string.Format("{0}:{1}", a.Time.Minutes, a.Time.Seconds)))
                .ReverseMap();

            CreateMap<UpdatePanelTutorialViewModel, PanelTutorial>().ReverseMap();
            CreateMap<CreatePanelTutorialViewModel, PanelTutorial>().ReverseMap();
            #endregion

            #region ( PaymentPortal )

            CreateMap<PaymentPortal, PaymentPortalViewModel>();
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
                .ForMember(src => src.Name, expression => expression.MapFrom(a => a.CityBase.Name))
                .ForMember(src => src.Route, expression => expression.MapFrom(a =>
                    !a.CityBase.Name.Contains("کرج") ? $"{a.CityBase.Name}-کرج".Trim().Replace(' ', '-') :
                    !a.CityBase.Name.Contains("-") ? a.CityBase.Name.Trim().Replace(' ', '-') : a.CityBase.Name))
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
            CreateMap<Comment, UpdateCommentViewModel>().ReverseMap();

            CreateMap<AnswerComment, CreateAnswerCommentViewModel>().ReverseMap();
            CreateMap<AnswerComment, CreateAnswerCommentCommand>().ReverseMap();
            CreateMap<AnswerComment, AnswerCommentViewModel>().ReverseMap();
            CreateMap<AnswerComment, UpdateAnswerCommentViewModel>().ReverseMap();
            #endregion

            #region ( Config )

            CreateMap<Config, ConfigViewModel>().ReverseMap();

            CreateMap<Config, AdminConfigViewModel>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));
            
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
                .ForMember(src => src.CityRoute, expression =>
                {
                    expression.PreCondition(a => a.City != null);
                    expression.MapFrom(a =>
                        !a.City.Name.Contains("کرج") ? $"{a.City.Name}-کرج".Trim().Replace(' ', '-') :
                        !a.City.Name.Contains("-") ? a.City.Name.Trim().Replace(' ', '-') : a.City.Name);
                })
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

            #region ( Discount )
            CreateMap<PromotionCode, CreateDiscountViewModel>().ReverseMap();
            CreateMap<PromotionCode, UpdateDiscountViewModel>().ReverseMap();
            #endregion

            #region ( Wallet )

            CreateMap<Wallet, WalletViewModel>().ReverseMap();

            #endregion

            CreateMap(typeof(CustomResult<>), typeof(Result<>)).ReverseMap();
        }
    }
}