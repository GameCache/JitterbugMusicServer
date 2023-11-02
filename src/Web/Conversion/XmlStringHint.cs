namespace JitterbugMusicServer.Web.Conversion;

/// <inheritdoc/>
public sealed class XmlStringHint<T>(string name, Func<T, string?> getter, Action<T, string?> setter)
    : BaseXmlHint<T, string?>(name, getter, setter)
{
    /// <inheritdoc/>
    protected override string? ConvertToString(string? value)
    {
        return value;
    }

    /// <inheritdoc/>
    protected override string? ConvertToData(string? value)
    {
        return value;
    }
}