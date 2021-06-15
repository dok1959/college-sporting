using CollegeSporting.Data;
using CollegeSporting.Models;

namespace CollegeSporting.Repositories
{
    public class CustomersUnitOfWork
    {
        private ApplicationContext _context;
        private IRepository<Customer> _customers;
        private IRepository<Country> _countries;

        public IRepository<Customer> Customers => _customers;

        public IRepository<Country> Countries => _countries;

        public CustomersUnitOfWork(ApplicationContext context)
        {
            _context = context;
            _customers = new Repository<Customer>(_context);
            _countries = new Repository<Country>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
