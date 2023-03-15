using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Data
{
    public class TrailersRepository : IRepository<Trailer>
    {
        private readonly LogisticContext _context;

        public TrailersRepository(LogisticContext context)
        {
            _context = context;
        }

        public void Create(Trailer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Trailers.Add(item);
        }

        public void Delete(Trailer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Trailers.Remove(item);
        }

        public IEnumerable<Trailer> GetAll()
        {
            return _context.Trailers.ToList();
        }

        public Trailer GetById(int id)
        {
            return _context.Trailers.FirstOrDefault(t => t.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Trailer item)
        {
            //nothing
        }
    }
}
