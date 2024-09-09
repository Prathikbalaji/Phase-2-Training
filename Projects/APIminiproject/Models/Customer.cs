using System.ComponentModel.DataAnnotations;

namespace APIminiproject.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Trip>? Trips { get; set; }
    }
}
