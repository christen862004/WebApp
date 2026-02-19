using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
