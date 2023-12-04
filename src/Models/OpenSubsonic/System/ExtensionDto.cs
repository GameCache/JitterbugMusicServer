using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;
using JitterbugMusic.Models.Conversion.Series;

namespace JitterbugMusic.Models.OpenSubsonic.System;

/// <summary>A supported OpenSubsonic API extension.</summary>
public sealed class ExtensionDto() : SubsonicContent<ExtensionDto>(
    "openSubsonicExtensions", "openSubsonicExtension", _ConvertAttributeHints, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ExtensionDto>> _ConvertAttributeHints = [
        new StringConvertHint<ExtensionDto>("name", m => m.Name, (m, v) => m.Name = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ExtensionDto>> _ConvertElementHints = [
        new IntSeriesConvertHint<ExtensionDto>(null, "version", m => m.Versions, (m, v) => m.Versions = v)
    ];

    /// <summary>Name of the extension.</summary>
    public string? Name { get; set; }

    /// <summary>Supported versions of the extension.</summary>
    public IEnumerable<int>? Versions { get; set; }
}
