namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Mvc.RazorPages;
using ConfidentialServices;

public static class PageModelExtensions
{
    /// <summary>
    /// Protect value before presenting it on the webpage.
    /// </summary>
    /// <param name="value">Value to protect.</param>
    /// <returns>Encrypted value to be displayed on webpage.</returns>
    public static string ProtectValue(this PageModel @this, string? value)
    {
        var isInt = int.TryParse(value, out var val);
        if (isInt)
        {
            var protectedValue = @this.HttpContext.RequestServices.GetRequiredService<IProtectIdTransform>().Protect((ConfidentialId)val);
            if (string.IsNullOrEmpty(protectedValue))
            {
                return string.Empty;
            }

            return protectedValue;
        }

        return string.Empty;
    }
}
