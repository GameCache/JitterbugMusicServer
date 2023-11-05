using System.Globalization;

namespace JitterbugMusic.Models.Conversion.Simple;

/// <inheritdoc/>
public sealed class DateTimeConvertHint<T>(string name, Func<T, DateTime?> getter, Action<T, DateTime?> setter)
    : BaseSimpleConvertHint<T, DateTime?>(name, getter, setter)
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