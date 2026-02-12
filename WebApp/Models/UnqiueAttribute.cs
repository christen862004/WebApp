using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class UnqiueAttribute:ValidationAttribute
    {
        ITIContext context = new ITIContext();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Employee EmpFromRequest = validationContext.ObjectInstance as Employee;//retirn obj from requesr


            string emailValue = value.ToString();
            Employee empFromDB= context.Employees
                .FirstOrDefault(e=>e.Email == emailValue && e.DepartmentID==EmpFromRequest.DepartmentID);
            
            if(empFromDB == null) {
                return ValidationResult.Success;
            }

            return new ValidationResult("Email Already Exist :(");
        }
    }
}
