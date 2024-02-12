using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Nested;
using JitterbugMusic.Models.Conversion.Simple;
using JitterbugMusic.Models.OpenSubsonic.AlbumSongLists;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>An artist from ID3 tags.</summary>
public sealed class ArtistDto() : SubsonicContent<ArtistDto>(
    "artists", "artist", _ConvertAttributeHints, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ArtistDto>> _ConvertAttributeHints = [
        new StringConvertHint<ArtistDto>("id", m => m.Id, (m, v) => m.Id = v),
        new StringConvertHint<ArtistDto>("name", m => m.Name, (m, v) => m.Name = v),
        new UriConvertHint<ArtistDto>("artistImageUrl", m => m.ArtistImageUrl, (m, v) => m.ArtistImageUrl = v),
        new DateTimeConvertHint<ArtistDto>("starred", m => m.Starred, (m, v) => m.Starred = v),
        new IntConvertHint<ArtistDto>("userRating", m => m.UserRating, (m, v) => m.UserRating = v),
        new DoubleConvertHint<ArtistDto>("averageRating", m => m.AverageRating, (m, v) => m.AverageRating = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ArtistDto>> _ConvertElementHints = [
        new NestedSeriesConvertHint<ArtistDto, AlbumId3Dto>("albums", "album", m => m.Album, (m, v) => m.Album = v)
    ];

    /// <summary>Artist id</summary>
    [Required]
    public string? Id { get; set; }

    /// <summary>Artist name</summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>Artist image url</summary>
    public Uri? ArtistImageUrl { get; set; }

    /// <summary>Artist starred date [ISO 8601]</summary>
    public DateTime? Starred { get; set; }

    /// <summary>Artist rating [1-5]</summary>
    public int? UserRating { get; set; }

    /// <summary>Artist average rating [1.0-5.0]</summary>
    public double? AverageRating { get; set; }

    /// <summary>Artist albums</summary>
    public IEnumerable<AlbumId3Dto>? Album { get; set; }
}
