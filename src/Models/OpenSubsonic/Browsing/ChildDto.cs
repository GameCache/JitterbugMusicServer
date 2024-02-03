using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Nested;
using JitterbugMusic.Models.Conversion.Series;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>A media.</summary>
public sealed class ChildDto() : SubsonicContent<ChildDto>(
    null, "child", _ConvertAttributeHints, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ChildDto>> _ConvertAttributeHints = [
        new StringConvertHint<ChildDto>("id", m => m.Id, (m, v) => m.Id = v),
        new StringConvertHint<ChildDto>("parent", m => m.Parent, (m, v) => m.Parent = v),
        new BoolConvertHint<ChildDto>("isDir", m => m.IsDir, (m, v) => m.IsDir = v),
        new StringConvertHint<ChildDto>("title", m => m.Title, (m, v) => m.Title = v),
        new StringConvertHint<ChildDto>("album", m => m.Album, (m, v) => m.Album = v),
        new StringConvertHint<ChildDto>("artist", m => m.Artist, (m, v) => m.Artist = v),
        new IntConvertHint<ChildDto>("track", m => m.Track, (m, v) => m.Track = v),
        new IntConvertHint<ChildDto>("year", m => m.Year, (m, v) => m.Year = v),
        new StringConvertHint<ChildDto>("genre", m => m.Genre, (m, v) => m.Genre = v),
        new StringConvertHint<ChildDto>("coverArt", m => m.CoverArt, (m, v) => m.CoverArt = v),
        new LongConvertHint<ChildDto>("size", m => m.Size, (m, v) => m.Size = v),
        new StringConvertHint<ChildDto>("contentType", m => m.ContentType, (m, v) => m.ContentType = v),
        new StringConvertHint<ChildDto>("suffix", m => m.Suffix, (m, v) => m.Suffix = v),
        new StringConvertHint<ChildDto>("transcodedContentType", m => m.TranscodedContentType, (m, v) => m.TranscodedContentType = v),
        new StringConvertHint<ChildDto>("transcodedSuffix", m => m.TranscodedSuffix, (m, v) => m.TranscodedSuffix = v),
        new IntConvertHint<ChildDto>("duration", m => m.Duration, (m, v) => m.Duration = v),
        new IntConvertHint<ChildDto>("bitRate", m => m.BitRate, (m, v) => m.BitRate = v),
        new StringConvertHint<ChildDto>("path", m => m.Path, (m, v) => m.Path = v),
        new BoolConvertHint<ChildDto>("isVideo", m => m.IsVideo, (m, v) => m.IsVideo = v),
        new IntConvertHint<ChildDto>("userRating", m => m.UserRating, (m, v) => m.UserRating = v),
        new DoubleConvertHint<ChildDto>("averageRating", m => m.AverageRating, (m, v) => m.AverageRating = v),
        new LongConvertHint<ChildDto>("playCount", m => m.PlayCount, (m, v) => m.PlayCount = v),
        new IntConvertHint<ChildDto>("discNumber", m => m.DiscNumber, (m, v) => m.DiscNumber = v),
        new DateTimeConvertHint<ChildDto>("created", m => m.Created, (m, v) => m.Created = v),
        new DateTimeConvertHint<ChildDto>("starred", m => m.Starred, (m, v) => m.Starred = v),
        new StringConvertHint<ChildDto>("albumId", m => m.AlbumId, (m, v) => m.AlbumId = v),
        new StringConvertHint<ChildDto>("artistId", m => m.ArtistId, (m, v) => m.ArtistId = v),
        new StringConvertHint<ChildDto>("type", m => m.Type, (m, v) => m.Type = v),
        new StringConvertHint<ChildDto>("mediaType", m => m.MediaType, (m, v) => m.MediaType = v),
        new LongConvertHint<ChildDto>("bookmarkPosition", m => m.BookmarkPosition, (m, v) => m.BookmarkPosition = v),
        new IntConvertHint<ChildDto>("originalWidth", m => m.OriginalWidth, (m, v) => m.OriginalWidth = v),
        new IntConvertHint<ChildDto>("originalHeight", m => m.OriginalHeight, (m, v) => m.OriginalHeight = v),
        new DateTimeConvertHint<ChildDto>("played", m => m.Played, (m, v) => m.Played = v),
        new IntConvertHint<ChildDto>("bpm", m => m.Bpm, (m, v) => m.Bpm = v),
        new StringConvertHint<ChildDto>("comment", m => m.Comment, (m, v) => m.Comment = v),
        new StringConvertHint<ChildDto>("sortName", m => m.SortName, (m, v) => m.SortName = v),
        new StringConvertHint<ChildDto>("musicBrainzId", m => m.MusicBrainzId, (m, v) => m.MusicBrainzId = v),
        new StringConvertHint<ChildDto>("displayArtist", m => m.DisplayArtist, (m, v) => m.DisplayArtist = v),
        new StringConvertHint<ChildDto>("displayAlbumArtist", m => m.DisplayAlbumArtist, (m, v) => m.DisplayAlbumArtist = v),
        new StringConvertHint<ChildDto>("displayComposer", m => m.DisplayComposer, (m, v) => m.DisplayComposer = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ChildDto>> _ConvertElementHints = [
        new NestedSeriesConvertHint<ChildDto, ItemGenreDto>("genres", "genre", m => m.Genres, (m, v) => m.Genres = v),
        new NestedSeriesConvertHint<ChildDto, ArtistId3Dto>("artists", "artist", m => m.Artists, (m, v) => m.Artists = v),
        new NestedSeriesConvertHint<ChildDto, ArtistId3Dto>("albumArtists", "albumArtist", m => m.AlbumArtists, (m, v) => m.AlbumArtists = v),
        new NestedSeriesConvertHint<ChildDto, ContributorDto>("contributors", "contributor", m => m.Contributors, (m, v) => m.Contributors = v),
        new StringSeriesConvertHint<ChildDto>("moods", "mood", m => m.Moods, (m, v) => m.Moods = v),
        new NestedConvertHint<ChildDto, ReplayGainDto>("replayGain", m => m.ReplayGain, (m, v) => m.ReplayGain = v)
    ];

    /// <summary>The id of the media</summary>
    [Required]
    public string? Id { get; set; }

    /// <summary>The id of the parent(folder/album)</summary>
    public string? Parent { get; set; }

    /// <summary>The media is a directory</summary>
    [Required]
    public bool? IsDir { get; set; }

    /// <summary>The media name.</summary>
    [Required]
    public string? Title { get; set; }

    /// <summary>The album name.</summary>
    public string? Album { get; set; }

    /// <summary>The artist name.</summary>
    public string? Artist { get; set; }

    /// <summary>The track number.</summary>
    public int? Track { get; set; }

    /// <summary>The media year.</summary>
    public int? Year { get; set; }

    /// <summary>The media genre</summary>
    public string? Genre { get; set; }

    /// <summary>A covertArt id.</summary>
    public string? CoverArt { get; set; }

    /// <summary>A file size of the media.</summary>
    public long? Size { get; set; }

    /// <summary>The mimeType of the media.</summary>
    public string? ContentType { get; set; }

    /// <summary>The file suffix of the media.</summary>
    public string? Suffix { get; set; }

    /// <summary>The transcoded mediaType if transcoding should happen.</summary>
    public string? TranscodedContentType { get; set; }

    /// <summary>The file suffix of the transcoded media.</summary>
    public string? TranscodedSuffix { get; set; }

    /// <summary>The duration of the media in seconds.</summary>
    public int? Duration { get; set; }

    /// <summary>The bitrate of the media.</summary>
    public int? BitRate { get; set; }

    /// <summary>The full path of the media.</summary>
    public string? Path { get; set; }

    /// <summary>Media is a video</summary>
    public bool? IsVideo { get; set; }

    /// <summary>The user rating of the media [1-5]</summary>
    public int? UserRating { get; set; }

    /// <summary>The average rating of the media[1.0 - 5.0]</summary>
    public double? AverageRating { get; set; }

    /// <summary>The play count.</summary>
    public long? PlayCount { get; set; }

    /// <summary>The disc number.</summary>
    public int? DiscNumber { get; set; }

    /// <summary>Date the media was created. [ISO 8601]</summary>
    public DateTime? Created { get; set; }

    /// <summary>Date the media was starred. [ISO 8601]</summary>
    public DateTime? Starred { get; set; }

    /// <summary>The corresponding album id</summary>
    public string? AlbumId { get; set; }

    /// <summary>The corresponding artist id</summary>
    public string? ArtistId { get; set; }

    /// <summary>The generic type of media[music / podcast / audiobook / video]</summary>
    public string? Type { get; set; }

    /// <summary>The actual media type[song / album / artist] Note: If you support musicBrainzId you must support this field to ensure clients knows what the ID refers to.</summary>
    public string? MediaType { get; set; } = "";

    /// <summary>The bookmark position in seconds</summary>
    public long? BookmarkPosition { get; set; }

    /// <summary>The video original Width</summary>
    public int? OriginalWidth { get; set; }

    /// <summary>The video original Height</summary>
    public int? OriginalHeight { get; set; }

    /// <summary>Date the album was last played. [ISO 8601]</summary>
    public DateTime? Played { get; set; } = DateTime.MinValue;

    /// <summary>The BPM of the song.</summary>
    public int? Bpm { get; set; } = 0;

    /// <summary>The comment tag of the song.</summary>
    public string? Comment { get; set; } = "";

    /// <summary>The song sort name.</summary>
    public string? SortName { get; set; }

    /// <summary>The track MusicBrainzID.</summary>
    public string? MusicBrainzId { get; set; } = "";

    /// <summary>The list of all genres of the song.</summary>
    public IEnumerable<ItemGenreDto>? Genres { get; set; } = [];

    /// <summary>The list of all song artists of the song. (Note: Only the required ArtistID3 fields should be returned by default)</summary>
    public IEnumerable<ArtistId3Dto>? Artists { get; set; } = [];

    /// <summary>The single value display artist.</summary>
    public string? DisplayArtist { get; set; } = "";

    /// <summary>The list of all album artists of the song. (Note: Only the required ArtistID3 fields should be returned by default)</summary>
    public IEnumerable<ArtistId3Dto>? AlbumArtists { get; set; } = [];

    /// <summary>The single value display album artist.</summary>
    public string? DisplayAlbumArtist { get; set; } = "";

    /// <summary>The list of all contributor artists of the song.</summary>
    public IEnumerable<ContributorDto>? Contributors { get; set; } = [];

    /// <summary>The single value display composer.</summary>
    public string? DisplayComposer { get; set; } = "";

    /// <summary>The list of all moods of the song.</summary>
    public IEnumerable<string>? Moods { get; set; } = [];

    /// <summary>The replay gain data of the song.</summary>
    public ReplayGainDto? ReplayGain { get; set; } = new();
}
