using CollegeSporting.Data;
using CollegeSporting.Models;

namespace CollegeSporting.Repositories
{
    public class RegistrationUnitOfWork
    {
        private ApplicationContext _context;
        private IRepository<Customer> _customers;
        private IRepository<Product> _products;
        private IRepository<Registration> _registrations;

        public IRepository<Customer> Customers => _customers;

        public IRepository<Product> Products => _products;

        public IRepository<Registration> Registrations => _registrations;

        public RegistrationUnitOfWork(ApplicationContext context)
        {
            _context = context;
            _customers = new Repository<Customer>(_context);
            _products = new Repository<Product>(_context);
            _registrations = new Repository<Registration>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
