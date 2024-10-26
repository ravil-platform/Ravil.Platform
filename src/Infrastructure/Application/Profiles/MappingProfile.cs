using AutoMapper;
using Domain.Entities.Faq;
using Domain.Entities.User;
using ViewModels.Faq;
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
        }
    }
}
