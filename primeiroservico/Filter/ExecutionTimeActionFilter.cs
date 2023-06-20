
using Microsoft.AspNetCore.Mvc.Filters;

namespace primeiroservico.Filter
{
    public class ExecutionTimeActionFilter : IActionFilter
    {
        private DateTime startTime;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            startTime = DateTime.Now;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            TimeSpan duration = DateTime.Now - startTime;
            Console.WriteLine($"Ação {context.ActionDescriptor.DisplayName} executada em {duration.TotalMilliseconds} ms.");
        }
    }
}