using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.AlbumSongLists;

/// <summary>MusicFolder.</summary>
public sealed class AlbumDto() : SubsonicContent<AlbumDto>(
    "albumList", "album", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<AlbumDto>> _ConvertAttributeHints = [
        new StringConvertHint<AlbumDto>("id", m => m.Id, (m, v) => m.Id = v),
        new StringConvertHint<AlbumDto>("parent", m => m.Parent, (m, v) => m.Parent = v),
        new StringConvertHint<AlbumDto>("album", m => m.Album, (m, v) => m.Album = v),
        new StringConvertHint<AlbumDto>("title", m => m.Title, (m, v) => m.Title = v),
        new StringConvertHint<AlbumDto>("name", m => m.Name, (m, v) => m.Name = v),
        new BoolConvertHint<AlbumDto>("isDir", m => m.IsDir, (m, v) => m.IsDir = v),
        new StringConvertHint<AlbumDto>("coverArt", m => m.CoverArt, (m, v) => m.CoverArt = v),
        new IntConvertHint<AlbumDto>("songCount", m => m.SongCount, (m, v) => m.SongCount = v),
        new DateTimeConvertHint<AlbumDto>("created", m => m.Created, (m, v) => m.Created = v),
        new IntConvertHint<AlbumDto>("duration", m => m.Duration, (m, v) => m.Duration = v),
        new IntConvertHint<AlbumDto>("playCount", m => m.PlayCount, (m, v) => m.PlayCount = v),
        new StringConvertHint<AlbumDto>("artistId", m => m.ArtistId, (m, v) => m.ArtistId = v),
        new StringConvertHint<AlbumDto>("artist", m => m.Artist, (m, v) => m.Artist = v),
        new IntConvertHint<AlbumDto>("year", m => m.Year, (m, v) => m.Year = v),
        new StringConvertHint<AlbumDto>("genre", m => m.Genre, (m, v) => m.Genre = v)
    ];

    public string? Id { get; set; }

    public string? Parent { get; set; }

    public string? Album { get; set; }

    public string? Title { get; set; }

    public string? Name { get; set; }

    public bool? IsDir { get; set; }

    public string? CoverArt { get; set; }

    public int? SongCount { get; set; }

    public DateTime? Created { get; set; }

    public int? Duration { get; set; }

    public int? PlayCount { get; set; }

    public string? ArtistId { get; set; }

    public string? Artist { get; set; }

    public int? Year { get; set; }

    public string? Genre { get; set; }
}
