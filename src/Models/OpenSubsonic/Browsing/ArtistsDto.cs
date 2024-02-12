using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Nested;
using JitterbugMusic.Models.Conversion.Series;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>Artist list.</summary>
public sealed class ArtistsDto() : SubsonicContent<ArtistsDto>(
    "artists", _ConvertAttributeHints, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ArtistsDto>> _ConvertAttributeHints = [
        new StringSeriesConvertHint<ArtistsDto>("ignoredArticles", " ", m => m.IgnoredArticles, (m, v) => m.IgnoredArticles = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ArtistsDto>> _ConvertElementHints = [
        new NestedSeriesConvertHint<ArtistsDto, IndexId3Dto>(null, "index", m => m.Index, (m, v) => m.Index = v)
    ];

    /// <summary>The ignored articles</summary>
    [JsonIgnore, Required]
    public IEnumerable<string>? IgnoredArticles { get; set; }

    /// <summary>Space delimited string of ignored articles.</summary>
    [JsonPropertyName("ignoredArticles")]
    public string? CombinedIgnoredArticles
    {
        get => (IgnoredArticles != null) ? string.Join(' ', IgnoredArticles) : null;
        set => IgnoredArticles = value?.Split(' ');
    }

    /// <summary>Indexed artists</summary>
    public IEnumerable<IndexId3Dto>? Index { get; set; }
}