using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Data
{
    public class BorderCrossingsRepository : IRepository<BorderCrossing>
    {
        private readonly LogisticContext _context;

        public BorderCrossingsRepository(LogisticContext context)
        {
            _context = context;
        }

        public void Create(BorderCrossing item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.BorderCrossings.Add(item);
        }

        public void Delete(BorderCrossing item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.BorderCrossings.Remove(item);
        }

        public IEnumerable<BorderCrossing> GetAll()
        {
            return _context.BorderCrossings.ToList();
        }

        public BorderCrossing GetById(int id)
        {
            return _context.BorderCrossings.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(BorderCrossing item)
        {
             //nothing
        }
    }
}
