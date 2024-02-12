using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Nested;
using JitterbugMusic.Models.Conversion.Series;
using JitterbugMusic.Models.Conversion.Simple;
using JitterbugMusic.Models.OpenSubsonic.Browsing;

namespace JitterbugMusic.Models.OpenSubsonic.AlbumSongLists;

/// <summary>An album from ID3 tags.</summary>
public sealed class AlbumId3Dto() : SubsonicContent<AlbumId3Dto>(
    "artists", "artist", _ConvertAttributeHints, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<AlbumId3Dto>> _ConvertAttributeHints = [
        new StringConvertHint<AlbumId3Dto>("id", m => m.Id, (m, v) => m.Id = v),
        new StringConvertHint<AlbumId3Dto>("name", m => m.Name, (m, v) => m.Name = v),
        new StringConvertHint<AlbumId3Dto>("artist", m => m.Artist, (m, v) => m.Artist = v),
        new StringConvertHint<AlbumId3Dto>("artistId", m => m.ArtistId, (m, v) => m.ArtistId = v),
        new StringConvertHint<AlbumId3Dto>("coverArt", m => m.CoverArt, (m, v) => m.CoverArt = v),
        new IntConvertHint<AlbumId3Dto>("songCount", m => m.SongCount, (m, v) => m.SongCount = v),
        new IntConvertHint<AlbumId3Dto>("duration", m => m.Duration, (m, v) => m.Duration = v),
        new LongConvertHint<AlbumId3Dto>("playCount", m => m.PlayCount, (m, v) => m.PlayCount = v),
        new DateTimeConvertHint<AlbumId3Dto>("created", m => m.Created, (m, v) => m.Created = v),
        new StringConvertHint<AlbumId3Dto>("starred", m => m.Starred, (m, v) => m.Starred = v),
        new IntConvertHint<AlbumId3Dto>("year", m => m.Year, (m, v) => m.Year = v),
        new StringConvertHint<AlbumId3Dto>("genre", m => m.Genre, (m, v) => m.Genre = v),
        new DateTimeConvertHint<AlbumId3Dto>("played", m => m.Played, (m, v) => m.Played = v),
        new IntConvertHint<AlbumId3Dto>("userRating", m => m.UserRating, (m, v) => m.UserRating = v),
        new StringConvertHint<AlbumId3Dto>("musicBrainzId", m => m.MusicBrainzId, (m, v) => m.MusicBrainzId = v),
        new StringConvertHint<AlbumId3Dto>("displayArtist", m => m.DisplayArtist, (m, v) => m.DisplayArtist = v),
        new StringConvertHint<AlbumId3Dto>("sortName", m => m.SortName, (m, v) => m.SortName = v),
        new BoolConvertHint<AlbumId3Dto>("isCompilation", m => m.IsCompilation, (m, v) => m.IsCompilation = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<AlbumId3Dto>> _ConvertElementHints = [
        new NestedSeriesConvertHint<AlbumId3Dto, RecordLabelDto>("recordLabels", "recordLabel", m => m.RecordLabels, (m, v) => m.RecordLabels = v),
        new NestedSeriesConvertHint<AlbumId3Dto, ItemGenreDto>("genres", "genre", m => m.Genres, (m, v) => m.Genres = v),
        new NestedSeriesConvertHint<AlbumId3Dto, ArtistId3Dto>("artists", "artist", m => m.Artists, (m, v) => m.Artists = v),
        new NestedConvertHint<AlbumId3Dto, ItemDateDto>("originalReleaseDate", m => m.OriginalReleaseDate, (m, v) => m.OriginalReleaseDate = v),
        new StringSeriesConvertHint<AlbumId3Dto>("releaseTypes", "releaseType", m => m.ReleaseTypes, (m, v) => m.ReleaseTypes = v),
        new StringSeriesConvertHint<AlbumId3Dto>("moods", "mood", m => m.Moods, (m, v) => m.Moods = v),
        new NestedSeriesConvertHint<AlbumId3Dto, DiscTitleDto>("discTitles", "discTitle", m => m.DiscTitles, (m, v) => m.DiscTitles = v)
    ];

    /// <summary>The id of the album</summary>
    [Required]
    public string? Id { get; set; }

    /// <summary>The album name.</summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>Artist name.</summary>
    public string? Artist { get; set; }

    /// <summary>The id of the artist</summary>
    public string? ArtistId { get; set; }

    /// <summary>A covertArt id.</summary>
    public string? CoverArt { get; set; }

    /// <summary>Number of songs</summary>
    [Required]
    public int? SongCount { get; set; }

    /// <summary>Total duration of the album</summary>
    [Required]
    public int? Duration { get; set; }

    /// <summary>Number of play of the album</summary>
    public long? PlayCount { get; set; }

    /// <summary>Date the album was added. [ISO 8601]</summary>
    [Required]
    public DateTime? Created { get; set; }

    /// <summary>Date the album was starred. [ISO 8601]</summary>
    public string? Starred { get; set; }

    /// <summary>The album year</summary>
    public int? Year { get; set; }

    /// <summary>The album genre</summary>
    public string? Genre { get; set; }

    /// <summary>Date the album was last played. [ISO 8601]</summary>
    public DateTime? Played { get; set; } = DateTime.MinValue;

    /// <summary>The user rating of the album. [1-5]</summary>
    public int? UserRating { get; set; } = 0;

    /// <summary>The labels producing the album.</summary>
    public IEnumerable<RecordLabelDto>? RecordLabels { get; set; } = [];

    /// <summary>The album MusicBrainzID.</summary>
    public string? MusicBrainzId { get; set; } = "";

    /// <summary>The list of all genres of the album.</summary>
    public IEnumerable<ItemGenreDto>? Genres { get; set; } = [];

    /// <summary>The list of all album artists of the album.</summary>
    /// <remarks>(Note: Only the required ArtistID3 fields should be returned by default)</remarks>
    public IEnumerable<ArtistId3Dto>? Artists { get; set; } = [];

    /// <summary>The single value display artist.</summary>
    public string? DisplayArtist { get; set; } = "";

    /// <summary>The types of this album release. (Album, Compilation, EP, Remix, …).</summary>
    public IEnumerable<string>? ReleaseTypes { get; set; } = [];

    /// <summary>The list of all moods of the album.</summary>
    public IEnumerable<string>? Moods { get; set; } = [];

    /// <summary>The album sort name.</summary>
    public string? SortName { get; set; } = "";

    /// <summary>Date the album was originally released.</summary>
    public ItemDateDto? OriginalReleaseDate { get; set; } = new ItemDateDto();

    /// <summary>True if the album is a compilation.</summary>
    public bool? IsCompilation { get; set; } = false;

    /// <summary>The list of all disc titles of the album.</summary>
    public IEnumerable<DiscTitleDto>? DiscTitles { get; set; } = [];
}