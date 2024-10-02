namespace ConfidentialServices;

/// <summary>
/// Interface for id transform.
/// </summary>
public interface IProtectIdTransform
{
    /// <summary>
    /// Protect id.
    /// </summary>
    /// <param name="id">Id which will be protected.</param>
    /// <returns>Protected id.</returns>
    string Protect(ConfidentialId id);

    /// <summary>
    /// Unprotect value and return id.
    /// </summary>
    /// <param name="value">Value which will be unprotected.</param>
    /// <returns>Unprotected id with type <see cref="ConfidentialId"/>.</returns>
    ConfidentialId? Unprotect(string value);
}