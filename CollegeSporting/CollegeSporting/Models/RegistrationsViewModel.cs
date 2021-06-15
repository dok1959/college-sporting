using System.Collections.Generic;

namespace CollegeSporting.Models
{
    public class RegistrationsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Registration> Registrations { get; set; }
        public Customer Customer { get; set; }

        public RegistrationsViewModel(IEnumerable<Product> products, IEnumerable<Registration> registrations, Customer customer)
        {
            Products = products;
            Customer = customer;
            Registrations = registrations;
        }
    }
}
