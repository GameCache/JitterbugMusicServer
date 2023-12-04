namespace JitterbugMusic.Models.Conversion.Series;

/// <inheritdoc/>
public sealed class StringSeriesConvertHint<T>(string? seriesName, string itemName,
    Func<T, IEnumerable<string>?> getter, Action<T, IEnumerable<string>?> setter)
    : BaseSeriesConvertHint<T, string>(seriesName, itemName, " ", getter, setter)
{
    /// <inheritdoc/>
    protected override string? ConvertToString(string value)
    {
        return value;
    }

    /// <inheritdoc/>
    protected override string ConvertToData(string value)
    {
        return value;
    }
}