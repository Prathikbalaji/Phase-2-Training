using System.ComponentModel.DataAnnotations;

namespace APIdemo.Models
{
    public class Organisation
    {
        [Key]
        public int OrgId { get; set; }
        public string? OrgName { get; set; }
        public ICollection<Employee>? Employee { get; set; }
    }
}
