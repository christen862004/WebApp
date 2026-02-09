using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context;
        public DepartmentController()
        {
            context = new ITIContext();
        }
        public IActionResult Index()
        {
            List<Department> deptList= context.Department.ToList();
            return View("Index",deptList);
        }
    }
}
