using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Data
{
    public class ClientsRepository : IRepository<Client>
    {
        private readonly LogisticContext _context;

        public ClientsRepository(LogisticContext context)
        {
            _context = context;
        }

        public void Create(Client item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Clients.Add(item);
        }

        public void Delete(Client item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.Clients.Remove(item);
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public Client GetById(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Client item)
        {
             //nothing
        }
    }
}
