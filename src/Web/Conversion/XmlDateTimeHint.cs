using System.Globalization;

namespace JitterbugMusicServer.Web.Conversion;

/// <inheritdoc/>
public sealed class XmlDateTimeHint<T>(string name, Func<T, DateTime?> getter, Action<T, DateTime?> setter)
    : BaseXmlHint<T, DateTime?>(name, getter, setter)
{
    /// <inheritdoc/>
    protected override string? ConvertToString(DateTime? value)
    {
        return value?.ToString("o", CultureInfo.InvariantCulture);
    }

    /// <inheritdoc/>
    protected override DateTime? ConvertToData(string? value)
    {
        return (value != null) ? DateTime.Parse(value, CultureInfo.InvariantCulture) : null;
    }
}