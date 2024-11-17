using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class XmlOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Verifica y agrega el tipo de contenido para el cuerpo de la solicitud
        if (operation.RequestBody != null &&
            !operation.RequestBody.Content.ContainsKey("application/xml"))
        {
            operation.RequestBody.Content.Add("application/xml", new OpenApiMediaType());
        }

        // Verifica y agrega el tipo de contenido para las respuestas
        foreach (var response in operation.Responses)
        {
            if (!response.Value.Content.ContainsKey("application/xml"))
            {
                response.Value.Content.Add("application/xml", new OpenApiMediaType());
            }
        }
    }
}
