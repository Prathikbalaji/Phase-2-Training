using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCcodefirst.Models
{
    public class Projects
    {
        [Key]
        public int Pid { get; set; }
        public string? ProName { get; set; }
        public DateTime? AllocatedDate { get; set; }
        public int Eid { get; set; }

        [ForeignKey("Eid")]
        public Employee? Employee { get; set; }
    }
}
