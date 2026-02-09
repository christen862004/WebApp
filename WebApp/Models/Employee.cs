using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public int Salary { get; set; }
        public string? Email { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
