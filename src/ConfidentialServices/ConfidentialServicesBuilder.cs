using Microsoft.Extensions.DependencyInjection;

namespace ConfidentialServices;

public sealed class ConfidentialServicesBuilder
{
    private readonly IServiceCollection services;

    internal ConfidentialServicesBuilder(IServiceCollection services)
    {
        this.services = services;
    }

    public IServiceCollection Services => services;
}
