namespace ConfidentialServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

internal class ConfigureConfidentialIdMvcOptions : IConfigureOptions<MvcOptions>
{
    /// <inheritdoc/>
    public void Configure(MvcOptions options)
    {
        options.ModelBinderProviders.Insert(0, new ConfidentialIdModelBinderProvider());
    }
}