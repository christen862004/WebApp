using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [MaxLength(50,ErrorMessage ="Name must be less than 50 letter")]
        [MinLength(3,ErrorMessage ="Name must be more than 2 Letter")]
        //[StringLength(50,MinimumLength =3)]
        //[Required]
        public string Name { get; set; }

        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="image must be jpg or png ex : asd.jpg")]
        public string ImageURL { get; set; }

        //[Range(8000,50000)]
        //[MoreThan(8000)]
        [Remote("CheckSalary","Employee",ErrorMessage ="Invalid Salary",AdditionalFields = "Name")]
        public int Salary { get; set; }//get /Employee/CheckSalary?Salary=1000

        [Unqiue]
        public string? Email { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        
        
        public Department? Department { get; set; }
    }
}
