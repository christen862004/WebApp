using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class BindController : Controller
    {
        /*
         <form method=get action="/Bind/TestPrimitive/99">
                <input name="name">
                <input name="age">
                <input name="color[0]">
                <input name="color">
                <input name="id">

         </form>
         */

        //Bind/TestPrimitive?age=12&name=ahmed&id=1&color=red&color=blue
        //Bind/TestPrimitive/1111?age=12&name=ahmed&color[0]=reb
        public IActionResult TestPrimitive(int age,string name,int id,string[] color)
        {
            return Content($"name={name}\t age={age}");
        }


        //test Collection list -stack -diction
        //Bind/TestDic?name=chirsten&PhoneBook[mohamed]=123&PhoneBook[ahmed]=456
        public IActionResult TestDic(Dictionary<string,string> PhoneBook,string name)
        {
            PhoneBook["mohamed"] = "123";
            return Content($"name={name}");

        }

        //test object "Custom Class"
        /*
         <inut name="Id">d
         <inut name="Name">d
         <inut name="ManagerNAme">d
         <inut name="Employeess[0].Name">d
         */
        //Bind/TestObj?id=1&name=sd&ManagerName=hamed
        //public IActionResult TestObj(int Id, string Name, string? ManagerName, List<Employee> Employees)
        public IActionResult TestObj(Department dept)//create object =new() [id,name,managername,employeeess]
        {
            return Ok("");
        }


        //Bind/MEthod1
        [HttpGet]
        public IActionResult Method1()
        {
            return Content("M1 -1");
        }
        //Bind/MEthod1
        //Bind/MEthod1/1
        [HttpPost]
        public IActionResult Method1(int id)
        {
            return Content("M1 with id");
        }
    }
}
