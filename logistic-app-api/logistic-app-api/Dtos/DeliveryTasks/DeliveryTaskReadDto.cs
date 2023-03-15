using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Dtos.DeliveryTasks
{
    public class DeliveryTaskReadDto
    {
        [Key]
        public int Id { get; set; }
        public User Driver { get; set; }
        public Car Car { get; set; }
        public Trailer Trailer { get; set; }
        public string From { get; set; }
        public string FromLocation { get; set; }
        public string FromContact { get; set; }
        public string To { get; set; }
        public string ToLocation { get; set; }
        public string ToCompanyBox { get; set; }
        public double Weight { get; set; }
        public string ContainerNumber { get; set; }
        public Client Client { get; set; }
        public Declarant Declarant { get; set; }
        public Customs Customs { get; set; }
        public BorderCrossing BorderCrossing { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }
        public string CurrentLocation { get; set; }
    }
}
