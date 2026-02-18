using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filtters
{
    public class MyActionAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //logic
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //logic

        }
    }
}
