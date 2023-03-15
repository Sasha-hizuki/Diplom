using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.Custom
{
    public class CustomsUpdateDto
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }
}
