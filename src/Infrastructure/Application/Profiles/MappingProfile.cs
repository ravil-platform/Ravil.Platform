using Application.Features.User.Commands.RegisterOrLogin;
using Microsoft.AspNetCore.Http.HttpResults;
using RNX.CustomResult;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base()
        {
            CreateMap<CreateUserViewModel, ApplicationUser>().ReverseMap();
            CreateMap<UpdateUserViewModel, ApplicationUser>().ReverseMap();
            CreateMap<RegisterOrLoginUserCommand, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, RegisterUserResponseViewModel>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();


            CreateMap<CreateFaqViewModel, Faq>().ReverseMap();
            CreateMap<UpdateFaqViewModel, Faq>().ReverseMap();

            CreateMap<CreateFaqCategoryViewModel, FaqCategory>().ReverseMap();
            CreateMap<UpdateFaqCategoryViewModel, FaqCategory>().ReverseMap();


            CreateMap<CreateUserCommand, ApplicationUser>().ReverseMap();

            CreateMap<Blog, BlogViewModel>().ReverseMap();
            CreateMap<BlogCategory, BlogCategoryViewModel>().ReverseMap();

            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryService, CategoryServiceViewModel>().ReverseMap();

            CreateMap<Job, JobViewModel>().ReverseMap();
            CreateMap<Job, CreateJobCommand>().ReverseMap();

            CreateMap<Job, CreateJobViewModel>().ReverseMap();
            CreateMap<JobBranch, CreateJobBranchViewModel>().ReverseMap();

            CreateMap<Job, UpdateJobCommand>().ReverseMap();

            CreateMap<JobCategory, CreateJobCategoryCommand>().ReverseMap();
            CreateMap<JobCategory, UpdateJobCategoryCommand>().ReverseMap();

            CreateMap<JobBranch, JobBranchViewModel>().ReverseMap();
            CreateMap<JobBranch, CreateJobBranchCommand>().ReverseMap();

            CreateMap<MainSlider, MainSliderViewModel>().ReverseMap();
            CreateMap<Service, ServiceViewModel>().ReverseMap();

            CreateMap<JobService, JobServiceViewModel>().ReverseMap();

            CreateMap<ShortLink, ShortLinkViewModel>().ReverseMap();
            CreateMap<JobSelectionSliderViewModel, JobSelectionSlider>().ReverseMap();


            CreateMap<JobBranchShortLink, JobBranchShortLinkViewModel>().ReverseMap();
            CreateMap<JobBranchGalleryViewModel, JobBranchGallery>().ReverseMap();

            CreateMap<JobTimeWork, JobTimeWorkViewModel>().ReverseMap();

            CreateMap<State, StateViewModel>().ReverseMap();
            CreateMap<StateBase, StateBaseViewModel>().ReverseMap();

            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<BlogTag, BlogTagViewModel>().ReverseMap();

            CreateMap<JobTag, JobTagViewModel>().ReverseMap();
            CreateMap<JobBranchTag, JobBranchTagViewModel>().ReverseMap();

            CreateMap<Team, TeamViewModel>().ReverseMap();
            CreateMap<Banner, BannerViewModel>().ReverseMap();

            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<City, CityViewModel>().ReverseMap();

            CreateMap<CityCategoryViewModel, CityCategory>().ReverseMap();
            CreateMap<CityBaseViewModel, CityBase>().ReverseMap();

            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<AnswerComment, AnswerCommentViewModel>().ReverseMap();

            CreateMap<Faq, FaqViewModel>().ReverseMap();
            CreateMap<FaqCategory, FaqCategoryViewModel>().ReverseMap();

            CreateMap<CreateCommentCommand, Comment>().ReverseMap();
            CreateMap<CreateAnswerCommentCommand, AnswerComment>().ReverseMap();

            CreateMap<Config, ConfigViewModel>().ReverseMap();
            CreateMap<Domain.Entities.DayOfWeek.DayOfWeek, DayOfWeekViewModel>().ReverseMap();


            CreateMap<UpdateJobBranchViewModel, JobBranch>().ReverseMap();
            CreateMap<TagViewModel, Tag>().ReverseMap();
            CreateMap<JobCategoriesView, JobCategory>().ReverseMap();


            CreateMap<UpdateJobBranchLocationCommand, JobBranch>().ReverseMap();

            CreateMap<Location, LocationViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();


            CreateMap<AddToBookMarkCommand, UserBookMark>().ReverseMap();
            CreateMap<AddBlogLikeCommand, UserBlogLike>().ReverseMap();


            CreateMap<UpdateUserInfoCommand, ApplicationUser>().ReverseMap();

            CreateMap(typeof(CustomResult<>),typeof(Result<>)).ReverseMap();
        }
    }
}