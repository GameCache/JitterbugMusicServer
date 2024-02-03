using System.Globalization;

namespace JitterbugMusic.Models.Conversion.Simple;

/// <inheritdoc/>
public sealed class DoubleConvertHint<T>(string name, Func<T, double?> getter, Action<T, double?> setter)
    : BaseSimpleConvertHint<T, double?>(name, getter, setter)
{
    /// <inheritdoc/>
    protected override string? ConvertToString(double? value)
    {
        return value?.ToString(CultureInfo.InvariantCulture);
    }

    /// <inheritdoc/>
    protected override double? ConvertToData(string? value)
    {
        return (value == null) ? null : double.Parse(value, CultureInfo.InvariantCulture);
    }
}