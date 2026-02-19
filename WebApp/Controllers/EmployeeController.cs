using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repository;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller //high level
    {
        //  ITIContext context;
        IEmployeeRepository EmployeeRepository;//low level
        IDepartmentRepository DepartmentRepository;
        public EmployeeController(IEmployeeRepository _empRepo, IDepartmentRepository _deptRepo)
        {
            EmployeeRepository=_empRepo;//DI
            DepartmentRepository=_deptRepo;
            //context = new ITIContext();
        }

        //  [AllowAnonymous]
        [Authorize]
        public IActionResult Index()
        {
            List<Employee> empList = EmployeeRepository.GetAll();//context.Employees.ToList();//Take &skip
            return View("Index", empList);
        }

        #region Valiadtion Salary
        public IActionResult CheckSalary(int Salary,string Name)
        {
            if (Salary > 8000)
            {
                return Json(true);
            }
            return Json(false);
        }
        #endregion

        #region NEw
        public IActionResult New()
        {
            ViewData["DeptList"] = DepartmentRepository.GetAll();// context.Department.ToList();
            return View("New");
        }

        [HttpPost]//check req method post
        [ValidateAntiForgeryToken]//if(request.form["_req"].valid
        public IActionResult SaveNew(Employee EmpFromReq)
        {
            if(ModelState.IsValid==true)//EmpFromReq.Name!=null& EmpFromReq.Salary > 8000) {
            {
                try
                {
                    EmployeeRepository.Add(EmpFromReq);
                    EmployeeRepository.Save();
                 //   context.Employees.Add(EmpFromReq);
                 //   context.SaveChanges();
                    return RedirectToAction("Index", "Employee");
                }catch (Exception ex)
                {
                    ModelState.AddModelError("any key",ex.InnerException.Message);
                }
            }
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View("New", EmpFromReq);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            //collect
            Employee EmpFromb = EmployeeRepository.GetById(id);// context.Employees.FirstOrDefault(e => e.Id == id);
            List<Department> DeptList = DepartmentRepository.GetAll();// context.Department.ToList();
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
                //MApping

                Employee empFromDb = new();// context.Employees.FirstOrDefault(e => e.Id == EmpFromReq.Id);
                empFromDb.Id = EmpFromReq.Id;//
                empFromDb.Salary = EmpFromReq.Salary;
                empFromDb.Name = EmpFromReq.EmpName;
                empFromDb.Email = EmpFromReq.Email;
                empFromDb.DepartmentID = EmpFromReq.DepartmentID;
                empFromDb.ImageURL = EmpFromReq.ImageURL;
                EmployeeRepository.Update(empFromDb);
                EmployeeRepository.Save();
                return RedirectToAction("Index","Employee");
            }


            EmpFromReq.DeptList = DepartmentRepository.GetAll();
            return View("Edit", EmpFromReq);
        }
        #endregion


        #region DEtails
        //Employee/Details/1?name=ahmed
        //Employee/Details?name=ahmed&id=1
        public IActionResult Details(int id,string name)
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



            Employee empModel = EmployeeRepository.GetById(id);
            return View("Details",empModel);
            //crate view ,send Model,send ViewData
        }

        public IActionResult DetailsVM(int id)
        {
            //Collect data
            int temp = 20;
            string msg = "Hello from Back";
            List<string> branches = new List<string>() { "Alex", "Cairo", "Sohag", "Assiut", "Monofia" };
            Employee empModel = EmployeeRepository.GetById(id);


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
