namespace ConfidentialServices;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Confidential id JSON converter.
/// </summary>
public class ConfidentialIdConverter : JsonConverter<ConfidentialId>
{
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfidentialIdConverter"/> class.
    /// </summary>
    /// <param name="httpContextAccessor">Http context accessor to use.</param>
    public ConfidentialIdConverter(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc/>
    public override ConfidentialId? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var transform = this.GetProtectIdTransform();
        var value = reader.GetString();
        if (value == null)
        {
            throw new InvalidOperationException("Cannot unprotect empty value.");
        }

        var confidentialId = transform.Unprotect(value);
        return confidentialId;
    }

    /// <inheritdoc/>
    public override void Write(
        Utf8JsonWriter writer,
        ConfidentialId value,
        JsonSerializerOptions options)
    {
        var transform = this.GetProtectIdTransform();
        writer.WriteStringValue(transform.Protect(value));
    }

    private IProtectIdTransform GetProtectIdTransform()
    {
        var services = this.httpContextAccessor.HttpContext?.RequestServices;
        if (services == null)
        {
            throw new InvalidOperationException("No services provided.");
        }

        return services.GetRequiredService<IProtectIdTransform>();
    }
}
