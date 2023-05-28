using System;
using AutoMapper;
using feedApi.Roles.dto;

namespace feedApi.Roles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CreateRoleDto, Role>();

            CreateMap<UpdateRoleDto, Role>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Role, RoleResponseDto>();
        }
    }
}

