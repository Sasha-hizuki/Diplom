using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.Destinations
{
    public class DestinationReadDto
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public string Location { get; set; }
    }
}
