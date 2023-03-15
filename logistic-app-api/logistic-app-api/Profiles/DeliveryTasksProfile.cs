using AutoMapper;
using logistic_app_api.Dtos;
using logistic_app_api.Dtos.DeliveryTasks;
using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Profiles
{
    public class DeliveryTasksProfile : Profile
    {
        public DeliveryTasksProfile()
        {
            //get/post DeliveryTask
            CreateMap<DeliveryTask, DeliveryTaskReadDto>();
            CreateMap<DeliveryTaskCreateDto, DeliveryTask>();
            //get DeliveryTask
            CreateMap<DeliveryTask, DeliveryTasksReadDto>();
            //update DeliveryTask
            CreateMap<DeliveryTaskUpdateDto, DeliveryTask>();
        }
    }
}
