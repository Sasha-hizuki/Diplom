using AutoMapper;
using logistic_app_api.Dtos;
using logistic_app_api.Dtos.Users;
using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            //get/post User
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            //get User
            CreateMap<User, UsersReadDto>();
            //update User
            CreateMap<UserUpdateDto, User>();
        }
    }
}
