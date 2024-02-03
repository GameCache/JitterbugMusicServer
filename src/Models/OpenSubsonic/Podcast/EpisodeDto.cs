using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Podcast;

/// <summary>MusicFolder.</summary>
public sealed class EpisodeDto() : SubsonicContent<EpisodeDto>(
    "episodes", "episode", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<EpisodeDto>> _ConvertAttributeHints = [
        new StringConvertHint<EpisodeDto>("id", m => m.Id, (m, v) => m.Id = v),
        new StringConvertHint<EpisodeDto>("streamId", m => m.StreamId, (m, v) => m.StreamId = v),
        new StringConvertHint<EpisodeDto>("channelId", m => m.ChannelId, (m, v) => m.ChannelId = v),
        new StringConvertHint<EpisodeDto>("title", m => m.Title, (m, v) => m.Title = v),
        new StringConvertHint<EpisodeDto>("description", m => m.Description, (m, v) => m.Description = v),
        new DateTimeConvertHint<EpisodeDto>("publishDate", m => m.PublishDate, (m, v) => m.PublishDate = v),
        new StringConvertHint<EpisodeDto>("status", m => m.Status, (m, v) => m.Status = v),
        new StringConvertHint<EpisodeDto>("parent", m => m.Parent, (m, v) => m.Parent = v),
        new BoolConvertHint<EpisodeDto>("isDir", m => m.IsDir, (m, v) => m.IsDir = v),
        new IntConvertHint<EpisodeDto>("year", m => m.Year, (m, v) => m.Year = v),
        new StringConvertHint<EpisodeDto>("genre", m => m.Genre, (m, v) => m.Genre = v),
        new StringConvertHint<EpisodeDto>("coverArt", m => m.CoverArt, (m, v) => m.CoverArt = v),
        new IntConvertHint<EpisodeDto>("size", m => m.Size, (m, v) => m.Size = v),
        new StringConvertHint<EpisodeDto>("contentType", m => m.ContentType, (m, v) => m.ContentType = v),
        new StringConvertHint<EpisodeDto>("suffix", m => m.Suffix, (m, v) => m.Suffix = v),
        new IntConvertHint<EpisodeDto>("duration", m => m.Duration, (m, v) => m.Duration = v),
        new IntConvertHint<EpisodeDto>("bitRate", m => m.BitRate, (m, v) => m.BitRate = v),
        new StringConvertHint<EpisodeDto>("path", m => m.Path, (m, v) => m.Path = v)
    ];

    /// <summary>The lyrics</summary>
    public string? Id { get; set; }

    /// <summary></summary>
    public string? StreamId { get; set; }

    /// <summary></summary>
    public string? ChannelId { get; set; }

    /// <summary>The song title</summary>
    public string? Title { get; set; }

    /// <summary>The song title</summary>
    public string? Description { get; set; }

    /// <summary></summary>
    public DateTime? PublishDate { get; set; }

    /// <summary></summary>
    public string? Status { get; set; }

    /// <summary></summary>
    public string? Parent { get; set; }

    /// <summary></summary>
    public bool? IsDir { get; set; }

    /// <summary></summary>
    public int? Year { get; set; }

    /// <summary></summary>
    public string? Genre { get; set; }

    /// <summary></summary>
    public string? CoverArt { get; set; }

    /// <summary></summary>
    public int? Size { get; set; }

    /// <summary></summary>
    public string? ContentType { get; set; }

    /// <summary></summary>
    public string? Suffix { get; set; }

    /// <summary></summary>
    public int? Duration { get; set; }

    /// <summary></summary>
    public int? BitRate { get; set; }

    /// <summary></summary>
    public string? Path { get; set; }
}