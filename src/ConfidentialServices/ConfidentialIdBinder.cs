namespace ConfidentialServices;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

/// <summary>
/// Model binder for the <see cref="ConfidentialId"/> class.
/// </summary>
public class ConfidentialIdBinder : IModelBinder
{
    private readonly IProtectIdTransform protectIdTransform;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfidentialIdBinder"/> class.
    /// </summary>
    /// <param name="protectIdTransform">Converter of the <see cref="ConfidentialId"/> class.</param>
    public ConfidentialIdBinder(IProtectIdTransform protectIdTransform)
    {
        this.protectIdTransform = protectIdTransform ?? throw new ArgumentNullException(nameof(protectIdTransform));
    }

    /// <inheritdoc/>
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var modelName = bindingContext.ModelName;
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
        var value = valueProviderResult.FirstValue;
        if (string.IsNullOrEmpty(value))
        {
            bindingContext.Result = ModelBindingResult.Success(null);
            return Task.CompletedTask;
        }

        var confidentialId = this.protectIdTransform.Unprotect(value);
        bindingContext.Result = ModelBindingResult.Success(confidentialId);
        return Task.CompletedTask;
    }
}