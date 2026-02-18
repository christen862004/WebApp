using Microsoft.AspNetCore.Mvc;
using WebApp.Filtters;

namespace WebApp.Controllers
{
    //r/Method1
    //r/Method2

    //[Route("r/{action}")]
   // [HandelError]
    public class RouteController : Controller
    {
        [HandelError]
        public IActionResult M1()
        {
            throw new Exception("Some Exxception happen:)");
        }
        //[HandelError]
        public IActionResult M2()
        {
            throw new Exception("Some Exxception happen:)");
        }


        //Route/Method1
        //r1?name=ahmed&id=12
        //r1/12/ahmed
        //r1/22/chtisten
        //r1/22
        [Route("r1/{id:int}/{name}")]//the only way reach this endpoint
        [HttpGet]
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
