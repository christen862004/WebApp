using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class MoreThanAttribute:ValidationAttribute
    {
        public int Number { get; set; }
        public MoreThanAttribute(int no)
        {
            Number = no;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int val = int.Parse(value.ToString());
            if (val > Number)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"number must be mpre than {Number}");
        }
    }
}
