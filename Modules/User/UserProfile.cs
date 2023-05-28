using System;
using AutoMapper;
using feedApi.Shared.Services.EncryptionService;
using feedApi.Users.dto;

namespace feedApi.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>()
                .ForMember(
                    dest => dest.Password,
                    opt => opt.MapFrom(src => EncryptionService.HashPassword(src.Password))
                );

            CreateMap<UpdateUserDto, User>()
                .ForMember(
                    dest => dest.Password,
                    opt => opt.MapFrom(src => EncryptionService.HashPassword(src.Password))
                )
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<User, UserResponseDto>();
        }
    }
}

