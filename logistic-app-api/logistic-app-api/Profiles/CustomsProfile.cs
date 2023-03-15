using AutoMapper;
using logistic_app_api.Dtos;
using logistic_app_api.Dtos.Custom;
using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Profiles
{
    public class CustomsProfile : Profile
    {
        public CustomsProfile()
        {
            //get/post Custom
            CreateMap<Customs, CustomsReadDto>();
            CreateMap<CustomsCreateDto, Customs>();
            //get Custom
            CreateMap<Customs, CustomsReadDto>();
            //update Custom
            CreateMap<CustomsUpdateDto, Customs>();
        }
    }
}
