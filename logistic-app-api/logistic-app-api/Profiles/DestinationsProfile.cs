using AutoMapper;
using logistic_app_api.Dtos;
using logistic_app_api.Dtos.Destinations;
using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Profiles
{
    public class DestinationsProfile : Profile
    {
        public DestinationsProfile()
        {
            //get/post Destination
            CreateMap<Destination, DestinationReadDto>();
            CreateMap<DestinationCreateDto, Destination>();
            //get Destination
            CreateMap<Destination, DestinationsReadDto>();
            //update Destination
            CreateMap<DestinationUpdateDto, Destination>();
        }
    }
}
