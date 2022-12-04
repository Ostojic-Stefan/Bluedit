using AutoMapper;
using Bluedit.Dtos;
using Bluedit.Entities;

namespace Bluedit.Services
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<UserRegisterDto, User>()
            //    .ForMember(dest => dest.PasswordHash, act => act.MapFrom(src => PasswordManager.HashPassword(src.Password)))
            //    .ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<PostCreationDto, Post>().ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
        }
    }
}
