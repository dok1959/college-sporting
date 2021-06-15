using CollegeSporting.Data;
using CollegeSporting.Models;

namespace CollegeSporting.Repositories
{
    public class IncidentsUnitOfWork
    {
        private ApplicationContext _context;
        private IRepository<Incident> _incidents;
        private IRepository<Customer> _customers;
        private IRepository<Product> _products;
        private IRepository<Technician> _technicians;

        public IRepository<Incident> Incidents => _incidents;

        public IRepository<Customer> Customers => _customers;

        public IRepository<Product> Products => _products;

        public IRepository<Technician> Technicians => _technicians;

        public IncidentsUnitOfWork(ApplicationContext context)
        {
            _context = context;
            _incidents = new Repository<Incident>(_context);
            _customers = new Repository<Customer>(_context);
            _products = new Repository<Product>(_context);
            _technicians = new Repository<Technician>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
