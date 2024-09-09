using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIdemo.Models
{
    public class Employee
    {
        [Key]
        public int empID {  get; set; }
        public string empName { get; set; }
        public decimal empSalary { get; set; }  
        public DateTime JoiningDate { get; set; }
        public int OrgID { get; set; }
        [ForeignKey("OrgID")]
        public Organisation? Organisation { get; set; }

    }
}
