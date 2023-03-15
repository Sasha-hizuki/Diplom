using logistic_app_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Data
{
    public class DeliveryTasksRepository : IRepository<DeliveryTask>
    {
        private readonly LogisticContext _context;

        public DeliveryTasksRepository(LogisticContext context)
        {
            _context = context;
        }

        public void Create(DeliveryTask item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            item.Driver = _context.Users.FirstOrDefault(t => t.Id == item.Driver.Id);
            item.Car = _context.Cars.FirstOrDefault(t => t.Id == item.Car.Id);
            item.Trailer = _context.Trailers.FirstOrDefault(t => t.Id == item.Trailer.Id);
            item.Client = _context.Clients.FirstOrDefault(t => t.Id == item.Client.Id);
            item.Declarant = _context.Declarants.FirstOrDefault(t => t.Id == item.Declarant.Id);
            item.Customs = _context.Customs.FirstOrDefault(t => t.Id == item.Customs.Id); 
            item.BorderCrossing = _context.BorderCrossings.FirstOrDefault(t => t.Id == item.BorderCrossing.Id);
            _context.DeliveryTasks.Add(item);
        }

        public void Delete(DeliveryTask item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.DeliveryTasks.Remove(item);
        }

        public IEnumerable<DeliveryTask> GetAll()
        {
            return _context.DeliveryTasks.ToList();
        }

        public DeliveryTask GetById(int id)
        {
            return _context.DeliveryTasks
                .Include(t=>t.Driver)
                .Include(t => t.Car)
                .Include(t => t.Trailer)
                .Include(t => t.Client)
                .Include(t => t.Declarant)
                .Include(t => t.Customs)
                .Include(t => t.BorderCrossing)
                .FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(DeliveryTask item)
        {
            item.Driver = _context.Users.FirstOrDefault(t => t.Id == item.Driver.Id);
            item.Car = _context.Cars.FirstOrDefault(t => t.Id == item.Car.Id);
            item.Client = _context.Clients.FirstOrDefault(t => t.Id == item.Client.Id);
            item.Declarant = _context.Declarants.FirstOrDefault(t => t.Id == item.Declarant.Id);
            item.Customs = _context.Customs.FirstOrDefault(t => t.Id == item.Customs.Id);
            item.BorderCrossing = _context.BorderCrossings.FirstOrDefault(t => t.Id == item.BorderCrossing.Id);
            //nothing
        }
    }
}
