using Microsoft.AspNetCore.Mvc;
using WebApp.Repository;

namespace WebApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ITestService testService;

        public ServiceController(ITestService testService)
        {
            this.testService = testService;
        }

        public IActionResult Index()
        {
            ViewData["Id"] = testService.Id;
            return View("Index");
        }
    }
}
