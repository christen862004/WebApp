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
        #region New
        public IActionResult New()
        {
            return View("New");//Model =null
        }
        //Department/SaveNEw?Name=&ManagerName=
        [HttpPost]//request method
        public IActionResult SaveNEw(Department deptFromRequest)
        {
            //if (Request.Method == "POST") {  }
            if (deptFromRequest.Name != null) {
                //SAve db
                context.Department.Add(deptFromRequest);//memeory
                context.SaveChanges();//throw excpetion

                return RedirectToAction("Index", "Department");
            }
            //return back view NEw
            return View("New",deptFromRequest);//view =New Model=Department
        }
        #endregion
    }
}
