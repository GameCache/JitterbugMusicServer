namespace JitterbugMusic.Models.Conversion.Simple;

/// <inheritdoc/>
public sealed class BoolConvertHint<T>(string name, Func<T, bool?> getter, Action<T, bool?> setter)
    : BaseSimpleConvertHint<T, bool?>(name, getter, setter)
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