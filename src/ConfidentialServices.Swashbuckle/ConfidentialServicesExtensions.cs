namespace Microsoft.Extensions.DependencyInjection;

using ConfidentialServices;
using Microsoft.OpenApi.Models;

public static class ConfidentialServicesExtensions
{
    public static ConfidentialServicesBuilder AddSwashbuckle(this ConfidentialServicesBuilder services)
    {
        services.Services.ConfigureSwaggerGen((c) =>
        {
            c.MapType<ConfidentialId>(() => new OpenApiSchema { Type = "string" });
        });
        return services;
    }
}
