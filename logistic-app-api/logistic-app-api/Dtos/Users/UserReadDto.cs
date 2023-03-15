using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.Users
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserPosition User_position { get; set; }
    }
}
