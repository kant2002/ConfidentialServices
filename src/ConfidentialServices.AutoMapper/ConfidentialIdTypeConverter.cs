namespace ConfidentialServices;


using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Confidential id resolver.
/// </summary>
public class ConfidentialIdTypeConverter : ITypeConverter<ConfidentialId, string>
{
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfidentialIdTypeConverter"/> class.
    /// </summary>
    /// <param name="httpContextAccessor">Http context accossor for use.</param>
    public ConfidentialIdTypeConverter(
        IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc/>
    public string Convert(ConfidentialId source, string destination, ResolutionContext context)
    {
        var services = this.httpContextAccessor.HttpContext?.RequestServices;
        if (services == null)
        {
            throw new InvalidOperationException("No services configured. Invalid setup.");
        }

        var protectIdTransform = services.GetRequiredService<IProtectIdTransform>();
        return protectIdTransform.Protect(source);
    }
}