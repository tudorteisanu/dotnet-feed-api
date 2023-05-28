using AutoMapper;
using feedApi.Shared.Services.EncryptionService;
using feedApi.Auth.dto;
using feedApi.Users;

namespace feedApi.Auth
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterRequestDto, User>()
                .ForMember(
                    dest => dest.Password,
                    opt => opt.MapFrom(src => EncryptionService.HashPassword(src.Password))
                );

        }
    }
}

