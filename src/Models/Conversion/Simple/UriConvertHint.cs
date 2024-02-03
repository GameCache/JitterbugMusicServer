using System.Text.Json;

namespace JitterbugMusic.Models.Conversion.Simple;

/// <inheritdoc/>
public sealed class UriConvertHint<T>(string name, Func<T, Uri?> getter, Action<T, Uri?> setter)
    : BaseSimpleConvertHint<T, Uri?>(name, getter, setter)
{
    /// <inheritdoc/>
    protected override string? ConvertToString(Uri? value)
    {
        return (value != null) ? JsonSerializer.Serialize(value) : null;
    }

    /// <inheritdoc/>
    protected override Uri? ConvertToData(string? value)
    {
        return (value != null) ? JsonSerializer.Deserialize<Uri>(value) : null;
    }
}