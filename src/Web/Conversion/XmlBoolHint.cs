namespace JitterbugMusicServer.Web.Conversion;

/// <inheritdoc/>
public sealed class XmlBoolHint<T>(string name, Func<T, bool?> getter, Action<T, bool?> setter)
    : BaseXmlHint<T, bool?>(name, getter, setter)
{
    /// <inheritdoc/>
    protected override string? ConvertToString(bool? value)
    {
        return (value == null) ? null : value.Value ? "true" : "false";
    }

    /// <inheritdoc/>
    protected override bool? ConvertToData(string? value)
    {
        return (value == null) ? null : value == "true";
    }
}