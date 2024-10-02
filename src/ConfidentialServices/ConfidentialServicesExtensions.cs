namespace Microsoft.Extensions.DependencyInjection;

using ConfidentialServices;

public static class ConfidentialServicesExtensions
{
    public static ConfidentialServicesBuilder AddConfidentialServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IProtectIdTransform, DataProtectorTransform>();
        services.ConfigureOptions<ConfigureConfidentialIdConverterJsonOptions>();
        services.ConfigureOptions<ConfigureConfidentialIdMvcOptions>();
        return new ConfidentialServicesBuilder(services);
    }
}