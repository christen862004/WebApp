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

        public IActionResult Index()
        {
            List<Employee> empList = context.Employees.ToList();
            return View("Index", empList);
        }
        #region Edit
        public IActionResult Edit(int id)
        {
            //collect
            Employee EmpFromb = context.Employees.FirstOrDefault(e => e.Id == id);
            List<Department> DeptList = context.Department.ToList();
            if(EmpFromb == null)
            {
                return NotFound();
            }
            //mapping
            //declare vm object
            EmpWithDeptListViewModel empVM = new()
            {
                Id = EmpFromb.Id,
                EmpName = EmpFromb.Name,
                Salary = EmpFromb.Salary,
                ImageURL = EmpFromb.ImageURL,
                DepartmentID = EmpFromb.DepartmentID,
                Email = EmpFromb.Email,
                DeptList = DeptList
            };
            return View("Edit", empVM);//ViewModel
        }
        [HttpPost]//EmpName
        public IActionResult SaveEdit(EmpWithDeptListViewModel EmpFromReq)//create new object - modle binding
        {
            if (EmpFromReq.EmpName != null)
            {
                Employee empFromDb = context.Employees.FirstOrDefault(e => e.Id == EmpFromReq.Id);

                empFromDb.Salary = EmpFromReq.Salary;
                empFromDb.Name = EmpFromReq.EmpName;
                empFromDb.Email = EmpFromReq.Email;
                empFromDb.DepartmentID = EmpFromReq.DepartmentID;
                empFromDb.ImageURL = EmpFromReq.ImageURL;

                context.SaveChanges();
                return RedirectToAction("Index","Employee");
            }

            
            EmpFromReq.DeptList = context.Department.ToList();
            return View("Edit", EmpFromReq);
        }
        #endregion
        #region DEtails
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
        #endregion
    }
}
