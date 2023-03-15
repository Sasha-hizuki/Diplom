﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.Cars
{
    public class CarCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public string Number { get; set; }
        public double Mileage { get; set; }
        public double Fuel_consumption { get; set; }
        public string VinNumber { get; set; }
        public DateTime TODate { get; set; }
        public DateTime BlrInsuranceDate { get; set; }
        public DateTime GCInsuranceDate { get; set; }
    }
}
