using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeSporting.Models
{
    public class Registration
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }

    }
}
