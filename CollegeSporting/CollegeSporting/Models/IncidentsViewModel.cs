using System.Collections.Generic;
using System.Linq;

namespace CollegeSporting.Models
{
    public class IncidentsViewModel
    {
        private IEnumerable<Customer> _customers;
        private IEnumerable<Product> _products;

        public IEnumerable<Incident> Incidents { get; set; }
        public string Filter { get; set; }
        public IncidentsViewModel(IEnumerable<Incident> incidents, IEnumerable<Customer> customers, IEnumerable<Product> products)
        {
            Incidents = incidents;
            _customers = customers;
            _products = products;
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