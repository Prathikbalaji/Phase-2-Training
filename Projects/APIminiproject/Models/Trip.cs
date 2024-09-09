using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIminiproject.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        public DateTime TripDate { get; set; }
        public string? StartLocation { get; set; }
        public string? EndLocation { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle? Vehicle { get; set; }
    }

}
