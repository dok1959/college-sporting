namespace CollegeSporting.Models
{
    public class TechnicidentViewModel
    {
        public string Technician;
        public string Product;
        public string Customer;
        public Incident Incident { get; set; }

        public TechnicidentViewModel(string technician, string product, string customer, Incident incident)
        {
            Technician = technician;
            Product = product;
            Customer = customer;
            Incident = incident;
        }
    }
}
