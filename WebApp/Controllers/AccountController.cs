using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userFromReq)
        {
            if(ModelState.IsValid) {
                //Addd usr databade
                ApplicationUser userModel = new ApplicationUser()
                {
                    UserName=userFromReq.UserName,
                    PasswordHash=userFromReq.Password,//Captal +samll +special +digit +length 6
                    Email=userFromReq.Email
                };
                IdentityResult result= await  userManager.CreateAsync(userModel,userFromReq.Password);
                if(result.Succeeded)
                {
                    //Assign this account ot Admin Role
                    await userManager.AddToRoleAsync(userModel, "Admin");//add Role
                    //Create cookie based on information appliactionused
                    await signInManager.SignInAsync(userModel,false); //Create cookie(S,P) , (id,username ,Email,Roles)
                    return RedirectToAction("Index", "Employee");
                }
                //error
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }

            }
            return View("Register",userFromReq);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                //chec db
                ApplicationUser userFromDB=await userManager.FindByNameAsync(userFromReq.UserName);
                if(userFromDB != null)
                {
                    //check pass
                    bool found=await userManager.CheckPasswordAsync(userFromDB, userFromReq.Password);
                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address", userFromDB.Address));

                        //create cookie//id,username ,email?,role? default claims +Address
                        await signInManager.SignInWithClaimsAsync(userFromDB, userFromReq.RememberMe,claims);//
                        return RedirectToAction("Index", "Employee");
                    }

                }

                ModelState.AddModelError("","Invalid Account ");
            }
            return View("Login",userFromReq);
        }
        #endregion

        #region SignOut
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #endregion
    }
}
