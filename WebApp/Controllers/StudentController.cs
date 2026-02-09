using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        
        StudentBL studentBL = new StudentBL();
        //Student/Index
        public IActionResult Index()
        {
            //ask model//get
            List<Student> studentList= studentBL.GetAll();
            //send to view
            return View("ShowAll",studentList);
            //how action send data to view   Model with type List<student>
            //Views/Stuednt/ShowAll
            //Views/Shared/ShowAll
            //exception
        }

        //using string
        //Student/Details/1
        //Student/Details?id=1
        public IActionResult Details(int id)
        {
            Student stdModel= studentBL.GetByID(id);
            if(stdModel != null)
            {
                return View("Details", stdModel);

            }
            return NotFound();
            //details ,model type Student
        }

    }
}
