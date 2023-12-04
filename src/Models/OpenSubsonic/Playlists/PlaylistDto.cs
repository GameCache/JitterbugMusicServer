using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Series;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Playlists;

/// <summary>...</summary>
public sealed class PlaylistDto() : SubsonicContent<PlaylistDto>(
    "playlists", "playlist", _ConvertAttributeHints, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<PlaylistDto>> _ConvertAttributeHints = [
        new StringConvertHint<PlaylistDto>("id", m => m.Id, (m, v) => m.Id = v),
        new StringConvertHint<PlaylistDto>("name", m => m.Name, (m, v) => m.Name = v),
        new StringConvertHint<PlaylistDto>("comment", m => m.Comment, (m, v) => m.Comment = v),
        new StringConvertHint<PlaylistDto>("owner", m => m.Owner, (m, v) => m.Owner = v),
        new BoolConvertHint<PlaylistDto>("public", m => m.Public, (m, v) => m.Public = v),
        new IntConvertHint<PlaylistDto>("songCount", m => m.SongCount, (m, v) => m.SongCount = v),
        new IntConvertHint<PlaylistDto>("duration", m => m.Duration, (m, v) => m.Duration = v),
        new DateTimeConvertHint<PlaylistDto>("created", m => m.Created, (m, v) => m.Created = v),
        new DateTimeConvertHint<PlaylistDto>("changed", m => m.Changed, (m, v) => m.Changed = v),
        new StringConvertHint<PlaylistDto>("coverArt", m => m.CoverArt, (m, v) => m.CoverArt = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<PlaylistDto>> _ConvertElementHints = [
        new StringSeriesConvertHint<PlaylistDto>(null, "allowedUser", m => m.AllowedUser, (m, v) => m.AllowedUser = v)
    ];

    /// <summary>Id of the playlist.</summary>
    public string? Id { get; set; }

    /// <summary>Name of the playlist.</summary>
    public string? Name { get; set; }

    /// <summary>A comment.</summary>
    public string? Comment { get; set; }

    /// <summary>Owner of the playlist.</summary>
    public string? Owner { get; set; }

    /// <summary>Is the playlist public</summary>
    public bool? Public { get; set; }

    /// <summary>Number of songs.</summary>
    public int? SongCount { get; set; }

    /// <summary>Playlist duration in seconds.</summary>
    public int? Duration { get; set; }

    /// <summary>Creation date [ISO 8601]</summary>
    public DateTime? Created { get; set; }

    /// <summary>Last changed date [ISO 8601]</summary>
    public DateTime? Changed { get; set; }

    /// <summary>A cover Art Id</summary>
    public string? CoverArt { get; set; }

    /// <summary>A list of allowed usernames</summary>
    public IEnumerable<string>? AllowedUser { get; set; }
}