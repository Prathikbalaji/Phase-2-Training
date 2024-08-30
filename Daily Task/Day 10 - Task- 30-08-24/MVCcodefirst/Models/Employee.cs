using System.ComponentModel.DataAnnotations;

namespace MVCcodefirst.Models
{
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        public string? EmpName { get; set; }
        public decimal? EmpSalary { get; set; }
        public string? EmpDesignation { get; set; }
        public string? EmpType { get; set; }

        public List<Projects>? Projects { get; set; }
    }
}
