using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        //Employee Data
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string ImageURL { get; set; }
        public int Salary { get; set; }
        public string? Email { get; set; }

        public int DepartmentID { get; set; }
        //MErge Model
        public List<Department> DeptList { get; set; }
    }
}
