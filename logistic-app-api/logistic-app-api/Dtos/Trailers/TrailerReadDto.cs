using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.Trailers
{
    public class TrailerReadDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public string VinNumber { get; set; }
        public DateTime TODate { get; set; }
        public DateTime BlrInsuranceDate { get; set; }
        public DateTime GCInsuranceDate { get; set; }
    }
}
