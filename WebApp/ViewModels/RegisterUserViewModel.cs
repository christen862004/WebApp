using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string? Email { get; set; }
    }
}
