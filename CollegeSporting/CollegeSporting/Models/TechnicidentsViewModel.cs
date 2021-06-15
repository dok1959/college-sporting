using System.Collections.Generic;
using System.Linq;

namespace CollegeSporting.Models
{
    public class TechnicidentsViewModel
    {
        private Technician _technician;
        private IEnumerable<Product> _products;
        private IEnumerable<Customer> _customers;
        public IEnumerable<Incident> Incidents { get; set; }

        public TechnicidentsViewModel(Technician technician, IEnumerable<Product> products, IEnumerable<Customer> customers, IEnumerable<Incident> incidents)
        {
            _technician = technician;
            _products = products;
            _customers = customers;
            Incidents = incidents;
        }

        public string GetTechnicianName()
        {
            return _technician.Name;
        }

        public string GetCustomerFullName(long id)
        {
            return _customers?.FirstOrDefault(x => x.Id == id)?.GetFullName();
        }

        public string GetProductName(long id)
        {
            return _products?.FirstOrDefault(x => x.Id == id)?.Name;
        }
    }
}
