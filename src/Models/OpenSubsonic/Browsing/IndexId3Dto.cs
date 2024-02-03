using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Nested;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>An indexed Artist list.</summary>
public sealed class IndexId3Dto() : SubsonicContent<IndexId3Dto>(
    "index", _ConvertAttributeHints, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<IndexId3Dto>> _ConvertAttributeHints = [
        new StringConvertHint<IndexId3Dto>("name", m => m.Name, (m, v) => m.Name = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<IndexId3Dto>> _ConvertElementHints = [
        new NestedSeriesConvertHint<IndexId3Dto, ArtistId3Dto>(null, "artist", m => m.Artist, (m, v) => m.Artist = v)
    ];

    /// <summary>Index name</summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>The artist name.</summary>
    [Required]
    public IEnumerable<ArtistId3Dto>? Artist { get; set; }
}