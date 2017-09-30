using AutoMapper;
using LTM.Application.Dto;
using LTM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Application.AutoMapperProfile
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}
