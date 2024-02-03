using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;
using JitterbugMusic.Models.Conversion.Nested;

namespace JitterbugMusic.Models.OpenSubsonic.Podcast;

/// <summary>MusicFolder.</summary>
public sealed class PodcastDto() : SubsonicContent<PodcastDto>(
    "podcasts", "channel", _ConvertAttributeHints, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<PodcastDto>> _ConvertAttributeHints = [
        new StringConvertHint<PodcastDto>("id", m => m.Id, (m, v) => m.Id = v),
        new UriConvertHint<PodcastDto>("url", m => m.Url, (m, v) => m.Url = v),
        new StringConvertHint<PodcastDto>("title", m => m.Title, (m, v) => m.Title = v),
        new StringConvertHint<PodcastDto>("description", m => m.Description, (m, v) => m.Description = v),
        new StringConvertHint<PodcastDto>("coverArt", m => m.CoverArt, (m, v) => m.CoverArt = v),
        new UriConvertHint<PodcastDto>("originalImageUrl", m => m.OriginalImageUrl, (m, v) => m.OriginalImageUrl = v),
        new StringConvertHint<PodcastDto>("status", m => m.Status, (m, v) => m.Status = v),
        new StringConvertHint<PodcastDto>("errorMessage", m => m.ErrorMessage, (m, v) => m.ErrorMessage = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<PodcastDto>> _ConvertElementHints = [
        new NestedSeriesConvertHint<PodcastDto, EpisodeDto>(null, "episode", m => m.Episodes, (m, v) => m.Episodes = v)
    ];

    /// <summary>The lyrics</summary>
    public string? Id { get; set; }

    /// <summary>The artist name</summary>
    public Uri? Url { get; set; }

    /// <summary>The song title</summary>
    public string? Title { get; set; }

    /// <summary>The song title</summary>
    public string? Description { get; set; }

    /// <summary>Cover art image.</summary>
    public string? CoverArt { get; set; }

    /// <summary>Where the cover art derived.</summary>
    public Uri? OriginalImageUrl { get; set; }

    /// <summary>State of the podcast.</summary>
    public string? Status { get; set; }

    /// <summary></summary>
    public string? ErrorMessage { get; set; }

    /// <summary></summary>
    public IEnumerable<EpisodeDto>? Episodes { get; set; }
}
