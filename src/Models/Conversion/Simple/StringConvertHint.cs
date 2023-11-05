namespace JitterbugMusic.Models.Conversion.Simple;

/// <inheritdoc/>
public sealed class StringConvertHint<T>(string name, Func<T, string?> getter, Action<T, string?> setter)
    : BaseSimpleConvertHint<T, string?>(name, getter, setter)
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