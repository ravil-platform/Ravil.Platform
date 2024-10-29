namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base()
        {
            CreateMap<CreateUserViewModel, ApplicationUser>().ReverseMap();
            CreateMap<UpdateUserViewModel, ApplicationUser>().ReverseMap();

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
        }
    }
}
