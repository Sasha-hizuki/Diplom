using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.Destinations
{
    public class DestinationCreateDto
    {
        [Required]
        public string Info { get; set; }
        public string Location { get; set; }
    }
}
