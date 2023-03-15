using AutoMapper;
using logistic_app_api.Dtos.Cars;
using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            //get/post car
            CreateMap<Car, CarReadDto>();
            CreateMap<CarCreateDto, Car>();
            //get cars
            CreateMap<Car, CarsReadDto>();
            //update car
            CreateMap<CarUpdateDto, Car>();
        }
    }
}
