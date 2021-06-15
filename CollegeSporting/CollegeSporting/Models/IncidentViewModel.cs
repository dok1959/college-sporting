using System.Collections.Generic;
using System.Linq;

namespace CollegeSporting.Models
{
    public class IncidentViewModel
    {
        public Incident Incident { get; set; }
        public IEnumerable<CustomerViewModel> Customers { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Technician> Technicians { get; set; }

        public string ActionPage;
    }
}
