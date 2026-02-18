using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Controllers
{
    public class StateController : Controller
    {
        //state/setsession?age=1&name=ahmed
        public IActionResult SetSession(int age,string name)
        {
            //logic
            //Store information in session per user
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);

            return Content("Session Save Sucess");
        }

        public IActionResult GetSession()
        {
            //logic
            string? n= HttpContext.Session.GetString("Name");
            int? a= HttpContext.Session.GetInt32("Age");
            //logic
            return Content($"Name={n}\t Age={a}");
        }

        public IActionResult SetCookie(int age,string name)
        {
            //logic 
            //Session Cookie 
            HttpContext.Response.Cookies.Append("Name", name);
            //Presistent Cookie  "Cookie with Expiration" 
            CookieOptions options = new CookieOptions();
            options.Expires=DateTimeOffset.Now.AddDays(1);

            HttpContext.Response.Cookies.Append("Age", age.ToString(),options);

            return Content("Cookie Save Success");
        }

        public IActionResult GetCookie()
        {
            string? name = HttpContext.Request.Cookies["Name"];
            string? age = HttpContext.Request.Cookies["Age"];
            return Content($"Name={name}\t Age={age}");
        }
    }
}
