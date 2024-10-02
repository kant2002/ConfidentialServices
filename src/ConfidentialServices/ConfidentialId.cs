namespace ConfidentialServices;
/// <summary>
/// Confidential id.
/// </summary>
public class ConfidentialId
{
    private readonly string value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfidentialId"/> class.
    /// </summary>
    /// <param name="value">Value which has to be hide.</param>
    public ConfidentialId(string value)
    {
        this.value = value;
    }

    /// <summary>
    /// Convert to <see cref="ConfidentialId"/> type explicit.
    /// </summary>
    /// <param name="value">Type of string which will be convert to <see cref="ConfidentialId"/>.</param>
#pragma warning disable CA2225 // Operator overloads have named alternates
    public static explicit operator ConfidentialId(int value)
    {
        return new ConfidentialId(value.ToString());
    }

    /// <summary>
    /// Convert to <see cref="ConfidentialId"/> type explicit.
    /// </summary>
    /// <param name="value">Type of string which will be convert to <see cref="ConfidentialId"/>.</param>
    public static explicit operator ConfidentialId(string value)
    {
        return new ConfidentialId(value);
    }

    /// <summary>
    /// Convert from <see cref="ConfidentialId"/>.
    /// </summary>
    /// <param name="id">Type of <see cref="ConfidentialId"/> which will be converted.</param>
    public static explicit operator string(ConfidentialId id)
    {
        return id.value.ToString();
    }

    /// <summary>
    /// Convert from <see cref="ConfidentialId"/>.
    /// </summary>
    /// <param name="id">Type of <see cref="ConfidentialId"/> which will be converted.</param>
    public static explicit operator int(ConfidentialId id)
    {
        return int.Parse(id.value);
    }

    /// <summary>
    /// Convert from <see cref="ConfidentialId"/>.
    /// </summary>
    /// <param name="id">Type of <see cref="ConfidentialId"/> which will be converted.</param>
    public static explicit operator int?(ConfidentialId? id)
    {
        if (id == null) return null;

        return int.Parse(id.value);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return this.value;
    }
}