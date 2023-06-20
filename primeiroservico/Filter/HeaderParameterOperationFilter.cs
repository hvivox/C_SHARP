
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;



namespace primeiroservico.Filter
{


    public class HeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-User-Token",
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema { Type = "string" },
                Description = "Descrição do parâmetro de cabeçalho"
            });
        }



    }
}