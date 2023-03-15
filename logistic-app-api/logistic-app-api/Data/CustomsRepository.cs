using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Data
{
    public class CustomsRepository : IRepository<Customs>
    {
        private readonly LogisticContext _context;

        public CustomsRepository(LogisticContext context)
        {
            _context = context;
        }

        public void Create(Customs item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Customs.Add(item);
        }

        public void Delete(Customs item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Customs.Remove(item);
        }

        public IEnumerable<Customs> GetAll()
        {
            return _context.Customs.ToList();
        }

        public Customs GetById(int id)
        {
            return _context.Customs.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Customs item)
        {
             //nothing
        }
    }
}
