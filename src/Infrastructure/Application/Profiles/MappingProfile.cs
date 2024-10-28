using AutoMapper;
using Domain.Entities.Blog;
using Domain.Entities.Category;
using Domain.Entities.Faq;
using ViewModels.Faq;
using ViewModels.QueriesResponseViewModel.Blog;
using ViewModels.QueriesResponseViewModel.Category;
using ViewModels.User;

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
        }
    }
}
