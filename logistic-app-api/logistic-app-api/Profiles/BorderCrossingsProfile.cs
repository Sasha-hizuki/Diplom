using AutoMapper;
using logistic_app_api.Dtos;
using logistic_app_api.Dtos.BorderCrossings;
using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Profiles
{
    public class BorderCrossingsProfile : Profile
    {
        public BorderCrossingsProfile()
        {
            //get/post BorderCrossing
            CreateMap<BorderCrossing, BorderCrossingReadDto>();
            CreateMap<BorderCrossingCreateDto, BorderCrossing>();
            //get BorderCrossing
            CreateMap<BorderCrossing, BorderCrossingsReadDto>();
            //update BorderCrossing
            CreateMap<BorderCrossingUpdateDto, BorderCrossing>();
        }
    }
}
