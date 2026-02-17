using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    //r/Method1
    //r/Method2
    

    public class RouteController : Controller
    {
        //Route/Method1
        //r1?name=ahmed&id=12
        //r1/12/ahmed
        //r1/22/chtisten
        //r1/22
        public IActionResult Method1(int id,string name)
        {
            return Content("M1");
        }

        //Route/Method2
        //r2
        public IActionResult Method2()
        {
            return Content("M2");
        }
    }
}
