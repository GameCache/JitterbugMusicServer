using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Series;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>An artist from ID3 tags.</summary>
public sealed class ArtistId3Dto() : SubsonicContent<ArtistId3Dto>(
    "artists", "artist", _ConvertAttributeHints, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ArtistId3Dto>> _ConvertAttributeHints = [
        new StringConvertHint<ArtistId3Dto>("id", m => m.Id, (m, v) => m.Id = v),
        new StringConvertHint<ArtistId3Dto>("name", m => m.Name, (m, v) => m.Name = v),
        new StringConvertHint<ArtistId3Dto>("coverArt", m => m.CoverArt, (m, v) => m.CoverArt = v),
        new UriConvertHint<ArtistId3Dto>("artistImageUrl", m => m.ArtistImageUrl, (m, v) => m.ArtistImageUrl = v),
        new IntConvertHint<ArtistId3Dto>("albumCount", m => m.AlbumCount, (m, v) => m.AlbumCount = v),
        new DateTimeConvertHint<ArtistId3Dto>("starred", m => m.Starred, (m, v) => m.Starred = v),
        new StringConvertHint<ArtistId3Dto>("musicBrainzId", m => m.MusicBrainzId, (m, v) => m.MusicBrainzId = v),
        new StringConvertHint<ArtistId3Dto>("sortName", m => m.SortName, (m, v) => m.SortName = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ArtistId3Dto>> _ConvertElementHints = [
        new StringSeriesConvertHint<ArtistId3Dto>("roles", "role", m => m.Roles, (m, v) => m.Roles = v)
    ];

    /// <summary>The id of the artist</summary>
    [Required]
    public string? Id { get; set; }

    /// <summary>The artist name.</summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>A covertArt id.</summary>
    public string? CoverArt { get; set; }

    /// <summary>An url to an external image source.</summary>
    public Uri? ArtistImageUrl { get; set; }

    /// <summary>Artist album count.</summary>
    public int? AlbumCount { get; set; }

    /// <summary>Date the artist was starred. [ISO 8601]</summary>
    public DateTime? Starred { get; set; }

    /// <summary>The artist MusicBrainzID.</summary>
    public string? MusicBrainzId { get; set; } = "";

    /// <summary>The artist sort name.</summary>
    public string? SortName { get; set; } = "";

    /// <summary>The list of all roles this artist have in the library.</summary>
    public IEnumerable<string>? Roles { get; set; } = [];
}