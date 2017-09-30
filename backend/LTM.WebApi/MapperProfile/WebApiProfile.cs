using AutoMapper;
using LTM.Application.Dto;
using LTM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTM.WebApi.MapperProfile
{
    public class WebApiProfile : Profile
    {
        public WebApiProfile()
        {
            CreateMap<UserProfileDto, UserProfileModel>();
            CreateMap<UserProfileModel, UserProfileDto>();

            CreateMap<ProductDto, ProductModel>();

        }
    }
}