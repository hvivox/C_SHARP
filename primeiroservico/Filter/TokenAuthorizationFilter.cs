using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace primeiroservico.Filter
{
    public class TokenAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Verifica se o token de autenticação está presente no cabeçalho da requisição
            if (!context.HttpContext.Request.Headers.TryGetValue("X-User-Token", out var token) || string.IsNullOrWhiteSpace(token))
            {
                // Caso o token seja inválido ou não seja enviado, retorna um erro 401 (Unauthorized)
                context.Result = new UnauthorizedResult();
            }

            // Verifica se o token é igual a "1234"
            if (token != "1234")
            {
                // Caso o token seja inválido, retorna um erro 401 (Unauthorized)
                context.Result = new UnauthorizedResult();
            }

        }
    }
}