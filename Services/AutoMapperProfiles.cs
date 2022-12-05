using AutoMapper;
using Bluedit.Dtos;
using Bluedit.Entities;
using Bluedit.Utils;

namespace Bluedit.Services
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<PostCreationDto, Post>()
                .ForMember(
                    dest => dest.Identifier,
                    act => act.MapFrom(src => Helpers.GenerateId(7))
                )
                .ForMember(
                    dest => dest.Slug,
                    act => act.MapFrom(src => Helpers.Slugify(src.Title))
                );
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<PostsWithUserDto, Post>().ReverseMap();
        }
    }
}
