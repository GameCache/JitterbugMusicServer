using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Sharing;

/// <summary>MusicFolder.</summary>
public sealed class ShareDto() : SubsonicContent<ShareDto>(
    "shares", "share", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ShareDto>> _ConvertAttributeHints = [
        new StringConvertHint<ShareDto>("id", m => m.Id, (m, v) => m.Id = v),
        new UriConvertHint<ShareDto>("url", m => m.Url, (m, v) => m.Url = v),
        new StringConvertHint<ShareDto>("description", m => m.Description, (m, v) => m.Description = v),
        new StringConvertHint<ShareDto>("username", m => m.Username, (m, v) => m.Username = v),
        new DateTimeConvertHint<ShareDto>("created", m => m.Created, (m, v) => m.Created = v),
        new DateTimeConvertHint<ShareDto>("expires", m => m.Expires, (m, v) => m.Expires = v),
        new DateTimeConvertHint<ShareDto>("lastVisited", m => m.LastVisited, (m, v) => m.LastVisited = v),
        new IntConvertHint<ShareDto>("visitCount", m => m.VisitCount, (m, v) => m.VisitCount = v)
    ];

    /// <summary>The share identifier.</summary>
    public string? Id { get; set; }

    /// <summary>The share url.</summary>
    public Uri? Url { get; set; }

    /// <summary>A description.</summary>
    public string? Description { get; set; }

    /// <summary>The username.</summary>
    public string? Username { get; set; }

    /// <summary>Creation date [ISO 8601]</summary>
    public DateTime? Created { get; set; }

    /// <summary>Share expiration [ISO 8601]</summary>
    public DateTime? Expires { get; set; }

    /// <summary>Last visit [ISO 8601]</summary>
    public DateTime? LastVisited { get; set; }

    /// <summary>Visit count.</summary>
    public int? VisitCount { get; set; }

    //entry	Array of Child	Yes		A list of share
}