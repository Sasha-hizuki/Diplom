using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.Declarants
{
    public class DeclarantCreateDto
    {
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
