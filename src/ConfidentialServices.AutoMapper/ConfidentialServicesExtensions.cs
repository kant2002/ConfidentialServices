namespace Microsoft.Extensions.DependencyInjection;

using AutoMapper;
using ConfidentialServices;

public static class ConfidentialServicesExtensions
{
    public static ConfidentialServicesBuilder AddAutoMapper(this ConfidentialServicesBuilder services)
    {
        services.Services.AddSingleton<Profile, ConfidentialMappingProfile>();
        return services;
    }
}
