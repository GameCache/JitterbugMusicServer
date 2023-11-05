using System.Globalization;

namespace JitterbugMusic.Models.Conversion.Simple;

/// <inheritdoc/>
public sealed class IntConvertHint<T>(string name, Func<T, int?> getter, Action<T, int?> setter)
    : BaseSimpleConvertHint<T, int?>(name, getter, setter)
{
    /// <inheritdoc/>
    protected override string? ConvertToString(int? value)
    {
        return value?.ToString(CultureInfo.InvariantCulture);
    }

    /// <inheritdoc/>
    protected override int? ConvertToData(string? value)
    {
        return (value == null) ? null : int.Parse(value, CultureInfo.InvariantCulture);
    }
}