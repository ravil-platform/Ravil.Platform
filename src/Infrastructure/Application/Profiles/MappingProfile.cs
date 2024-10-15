using AutoMapper;
using Domain.Entities.User;
using ViewModels.User;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base()
        {
            CreateMap<CreateUserViewModel, ApplicationUser>().ReverseMap();
        }
    }
}
