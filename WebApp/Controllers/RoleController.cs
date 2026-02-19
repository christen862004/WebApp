using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        //[Authorize(Roles ="Admin")]//chec kfound cooie ==> Role Admin
        public IActionResult Create()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleFromReq)
        {
            if(ModelState.IsValid)
            {
                //Save
                IdentityRole role = new IdentityRole() { Name = roleFromReq.RoleName };
                IdentityResult result= await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Department");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(roleFromReq);
        }
    }
}
