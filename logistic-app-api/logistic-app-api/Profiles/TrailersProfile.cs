using AutoMapper;
using logistic_app_api.Dtos;
using logistic_app_api.Dtos.Trailers;
using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Profiles
{
    public class TrailersProfile : Profile
    {
        public TrailersProfile()
        {
            //get/post trailer
            CreateMap<Trailer, TrailerReadDto>();
            CreateMap<TrailerCreateDto, Trailer>();
            //get trailers
            CreateMap<Trailer, TrailersReadDto>();
            //update trailer
            CreateMap<TrailerUpdateDto, Trailer>();
        }
    }
}
