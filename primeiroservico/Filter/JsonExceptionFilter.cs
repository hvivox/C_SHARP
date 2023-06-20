
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

// ExceptionHandler: Centraliza a exceções para mostrar uma mensagem de erro generica
namespace primeiroservico.Filter
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.Result = new JsonResult(new { error = "Ocorreu um erro no servidor. Tente novamente mais tarde!" })
            {
                StatusCode = 500
            };

        }
    }
}