using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context;
        public EmployeeController()
        {
            context = new ITIContext();
        }
        public IActionResult Details(int id)
        {
            //logic infomation
            int temp = 20;
            string msg = "Hello from Back";
            List<string> branches = new List<string>() { "Alex", "Cairo", "Sohag", "Assiut", "Monofia" };

            //Send using ViewData (set)
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["Branches"] = branches;
            ViewData["Color"] = "blue";//oveeride 
            ViewBag.Color = "red";//ViewData["Color"]="red"



            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);
            return View("Details",empModel);
            //crate view ,send Model,send ViewData
        }

        public IActionResult DetailsVM(int id)
        {
            //Collect data
            int temp = 20;
            string msg = "Hello from Back";
            List<string> branches = new List<string>() { "Alex", "Cairo", "Sohag", "Assiut", "Monofia" };
            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);

            //decalre VM
            EmpWithBracnshMsgTempColorViewModel EmpVm = new() { 
                EmpId=empModel.Id,
                EmpName=empModel.Name,
                Message=msg,
                Temp=temp,
                Color= "red",
                Branches=branches
            };

            //Map source ==>vm
            //EmpVm.EmpId = empModel.Id;
            //send Vm to View
            return View("DetailsVM", EmpVm);//EmpWithBracnshMsgTempColorViewModel
        }
    }
}
