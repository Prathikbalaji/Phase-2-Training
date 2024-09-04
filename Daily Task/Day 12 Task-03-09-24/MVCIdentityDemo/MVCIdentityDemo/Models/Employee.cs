using System.ComponentModel.DataAnnotations;

namespace MVCIdentityDemo.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        public string EmpName { get; set; }

        public string EmpDesig { get; set; }
    }
}
