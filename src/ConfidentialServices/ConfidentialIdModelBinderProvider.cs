namespace ConfidentialServices;

using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Custom binder provider.
/// </summary>
public class ConfidentialIdModelBinderProvider : IModelBinderProvider
{
    /// <inheritdoc/>
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var modelType = context.Metadata.ModelType;
        if (modelType == typeof(ConfidentialId))
        {
            var scope = context.Services.CreateScope();
            var protectIdTransform = scope.ServiceProvider.GetRequiredService<IProtectIdTransform>();
            return new ConfidentialIdBinder(protectIdTransform);
        }

        return null;
    }
}