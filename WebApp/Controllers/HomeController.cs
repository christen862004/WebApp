using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    /*
     1) controller name suffix (end With) Controller
     2) class inherit from Controller Class (httpContext (req- res- user))
     */
    public class HomeController : Controller
    {
        //Home/ShowMsg endpoint
        public ContentResult ShowMsg()
        {
            //logic

            //declare emplpoiyee
            ContentResult result = new ContentResult();
            //fill ddata
            result.Content = "Welcome From First Action";
            //resturn
            return result;
        }
        //Home/ShowView
        public ViewResult ShowView()
        {
            //logic
            //declare
            return View("View1");
        }

        //Home/ShowMix?id=1&no=1&name=ahmed
        //Home/ShowMix/1?no=1&name=ahmed
        public IActionResult ShowMix(int no,string name,int id)
        {
            if (no % 2 == 0)
            {
                //logic
                return View("View1");
            }
            else
            {
                //declare emplpoiyee
                return Content("Hi from Action ");
            }
        }
        //public ViewResult View(string viewname)
        //{
        //    //declare
        //    ViewResult result = new ViewResult();
        //    // fill dta
        //    result.ViewName = viewname;
        //    //return
        //    return result;
        //}

        /*
         return action  share the same parent
        1- content  => ContentResult    ==> Content()
        2- view     => ViewResult       ==> View()
        3- json     => JsonResult       ==> Json()
        4- notfound => NotFounddResult  ==> NotFount()
        5- unauthorize =>UnazuthorizeReuslt
        ......
         */






        /* methd call acion "endpoint"
         1) method must be public 
         2) method cant be static
         3) method cant be Overload (only in one cast)
         */


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
