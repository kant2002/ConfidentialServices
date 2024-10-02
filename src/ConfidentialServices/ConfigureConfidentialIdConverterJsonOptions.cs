namespace ConfidentialServices;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

/// <summary>
/// Confidential id converter json options.
/// </summary>
public class ConfigureConfidentialIdConverterJsonOptions : IConfigureOptions<JsonOptions>
{
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureConfidentialIdConverterJsonOptions"/> class.
    /// </summary>
    /// <param name="httpContextAccessor">Http context accossor for use.</param>
    public ConfigureConfidentialIdConverterJsonOptions(
        IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc/>
    public void Configure(JsonOptions options)
    {
        options.JsonSerializerOptions.Converters.Add(
            new ConfidentialIdConverter(
                this.httpContextAccessor));
    }
}