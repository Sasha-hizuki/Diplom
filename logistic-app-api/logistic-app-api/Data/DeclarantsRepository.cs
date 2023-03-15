using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Data
{
    public class DeclarantsRepository : IRepository<Declarant>
    {
        private readonly LogisticContext _context;

        public DeclarantsRepository(LogisticContext context)
        {
            _context = context;
        }

        public void Create(Declarant item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Declarants.Add(item);
        }

        public void Delete(Declarant item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Declarants.Remove(item);
        }

        public IEnumerable<Declarant> GetAll()
        {
            return _context.Declarants.ToList();
        }

        public Declarant GetById(int id)
        {
            return _context.Declarants.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Declarant item)
        {
             //nothing
        }
    }
}
