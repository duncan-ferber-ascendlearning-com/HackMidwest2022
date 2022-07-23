using AutoMapper;
using SecureBadge.Entities;
using SecureBadge.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureBadge
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, User>()
                            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
        
    }
}
