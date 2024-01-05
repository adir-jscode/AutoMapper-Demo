using AutoMapper.API.Dtos;
using AutoMapper.API.Models;
using AutoMapper.API.HelperFunctions;

namespace AutoMapper.API.AMProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge())
                    );

            //souce to destination
            CreateMap<UserCreateDto,User> ();
        }
    }
}
