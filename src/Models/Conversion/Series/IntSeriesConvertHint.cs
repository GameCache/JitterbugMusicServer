using System.Globalization;

namespace JitterbugMusic.Models.Conversion.Series;

/// <inheritdoc/>
public sealed class IntSeriesConvertHint<T>(string? seriesName, string itemName,
    Func<T, IEnumerable<int>?> getter, Action<T, IEnumerable<int>?> setter)
    : BaseSeriesConvertHint<T, int>(seriesName, itemName, " ", getter, setter)
{
    /// <inheritdoc/>
    protected override string? ConvertToString(int value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }

    /// <inheritdoc/>
    protected override int ConvertToData(string value)
    {
        return int.Parse(value, CultureInfo.InvariantCulture);
    }
}