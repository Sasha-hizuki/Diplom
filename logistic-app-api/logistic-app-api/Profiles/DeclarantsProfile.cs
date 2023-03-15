using AutoMapper;
using logistic_app_api.Dtos;
using logistic_app_api.Dtos.Declarants;
using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Profiles
{
    public class DeclarantsProfile : Profile
    {
        public DeclarantsProfile()
        {
            //get/post Declarant
            CreateMap<Declarant, DeclarantReadDto>();
            CreateMap<DeclarantCreateDto, Declarant>();
            //get Declarant
            CreateMap<Declarant, DeclarantsReadDto>();
            //update Declarant
            CreateMap<DeclarantUpdateDto, Declarant>();
        }
    }
}
