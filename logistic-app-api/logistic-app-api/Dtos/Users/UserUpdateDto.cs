using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.Users
{
    public class UserUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string FIO { get; set; }
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public UserPosition User_position { get; set; }
    }
}
