namespace ConfidentialServices;

using Microsoft.AspNetCore.DataProtection;

/// <summary>
/// Class which do not protect id and return same value.
/// </summary>
public class IdentityTransform : IProtectIdTransform
{
    private readonly IDataProtector dataProtector;

    /// <summary>
    /// Initializes a new instance of the <see cref="IdentityTransform"/> class.
    /// </summary>
    /// <param name="provider">Data protection provider to use.</param>
    public IdentityTransform(IDataProtectionProvider provider)
    {
        this.dataProtector = provider.CreateProtector("IdentityTransform.v1");
    }

    /// <inheritdoc/>
    public string Protect(ConfidentialId id)
    {
        var unprotectedValue = (string)id;
        var result = this.dataProtector.Protect(unprotectedValue);
        return result;
    }

    /// <inheritdoc/>
    public ConfidentialId? Unprotect(string value)
    {
        try
        {
            var result = this.dataProtector.Unprotect(value);
            return (ConfidentialId)result;
        }
        catch (System.Exception)
        {
            return null;
        }
    }
}