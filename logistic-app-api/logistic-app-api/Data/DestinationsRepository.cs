using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Data
{
    public class DestinationsRepository : IRepository<Destination>
    {
        private readonly LogisticContext _context;

        public DestinationsRepository(LogisticContext context)
        {
            _context = context;
        }

        public void Create(Destination item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Destinations.Add(item);
        }

        public void Delete(Destination item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Destinations.Remove(item);
        }

        public IEnumerable<Destination> GetAll()
        {
            return _context.Destinations.ToList();
        }

        public Destination GetById(int id)
        {
            return _context.Destinations.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Destination item)
        {
             //nothing
        }
    }
}
