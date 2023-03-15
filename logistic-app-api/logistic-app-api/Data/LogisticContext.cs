using logistic_app_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Data
{
    public class LogisticContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Declarant> Declarants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }
        public DbSet<BorderCrossing> BorderCrossings { get; set; }
        public DbSet<Customs> Customs { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<DeliveryTask> DeliveryTasks { get; set; }


        public LogisticContext(DbContextOptions<LogisticContext> opt) : base(opt)
        {
         
        }        
    }
}
