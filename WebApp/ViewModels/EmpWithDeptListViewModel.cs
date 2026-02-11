using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        //Employee Data
        public int Id { get; set; }
        //???????????
        [Display(Name ="Employee Name")]//1)
        //[DataType(DataType.Password)]//1)determin input type 
        public string EmpName { get; set; }//2)//2)property type ddetermine input type

        public string ImageURL { get; set; }
        public int Salary { get; set; }
        public string? Email { get; set; }

        public int DepartmentID { get; set; }
        //MErge Model
        public List<Department> DeptList { get; set; }
    }
}
