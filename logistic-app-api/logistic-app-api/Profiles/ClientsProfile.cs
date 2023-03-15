using AutoMapper;
using logistic_app_api.Dtos;
using logistic_app_api.Dtos.Clients;
using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Profiles
{
    public class ClientsProfile : Profile
    {
        public ClientsProfile()
        {
            //get/post Client
            CreateMap<Client, ClientReadDto>();
            CreateMap<ClientCreateDto, Client>();
            //get Client
            CreateMap<Client, ClientsReadDto>();
            //update Client
            CreateMap<ClientUpdateDto, Client>();
        }
    }
}
