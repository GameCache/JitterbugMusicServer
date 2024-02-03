using System.Globalization;

namespace JitterbugMusic.Models.Conversion.Simple;

/// <inheritdoc/>
public sealed class LongConvertHint<T>(string name, Func<T, long?> getter, Action<T, long?> setter)
    : BaseSimpleConvertHint<T, long?>(name, getter, setter)
{
    /// <inheritdoc/>
    protected override string? ConvertToString(long? value)
    {
        return value?.ToString(CultureInfo.InvariantCulture);
    }

    /// <inheritdoc/>
    protected override long? ConvertToData(string? value)
    {
        return (value == null) ? null : long.Parse(value, CultureInfo.InvariantCulture);
    }
}