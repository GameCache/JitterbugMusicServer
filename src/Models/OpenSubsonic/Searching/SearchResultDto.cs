using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Searching;

/// <summary>MusicFolder.</summary>
public sealed class SearchResultDto() : SubsonicContent<SearchResultDto>(
    "searchResult", "match", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<SearchResultDto>> _ConvertAttributeHints = [
        new StringConvertHint<SearchResultDto>("id", m => m.Id, (m, v) => m.Id = v),
        new StringConvertHint<SearchResultDto>("parent", m => m.Parent, (m, v) => m.Parent = v),
        new StringConvertHint<SearchResultDto>("title", m => m.Title, (m, v) => m.Title = v),
        new BoolConvertHint<SearchResultDto>("isDir", m => m.IsDir, (m, v) => m.IsDir = v),
        new StringConvertHint<SearchResultDto>("album", m => m.Album, (m, v) => m.Album = v),
        new StringConvertHint<SearchResultDto>("artist", m => m.Artist, (m, v) => m.Artist = v),
        new IntConvertHint<SearchResultDto>("track", m => m.Track, (m, v) => m.Track = v),
        new IntConvertHint<SearchResultDto>("year", m => m.Year, (m, v) => m.Year = v),
        new StringConvertHint<SearchResultDto>("genre", m => m.Genre, (m, v) => m.Genre = v),
        new StringConvertHint<SearchResultDto>("coverArt", m => m.CoverArt, (m, v) => m.CoverArt = v),
        new IntConvertHint<SearchResultDto>("size", m => m.Size, (m, v) => m.Size = v),
        new StringConvertHint<SearchResultDto>("contentType", m => m.ContentType, (m, v) => m.ContentType = v),
        new StringConvertHint<SearchResultDto>("suffix", m => m.Suffix, (m, v) => m.Suffix = v),
        new StringConvertHint<SearchResultDto>("transcodedContentType", m => m.TranscodedContentType, (m, v) => m.TranscodedContentType = v),
        new StringConvertHint<SearchResultDto>("transcodedSuffix", m => m.TranscodedSuffix, (m, v) => m.TranscodedSuffix = v),
        new StringConvertHint<SearchResultDto>("path", m => m.Path, (m, v) => m.Path = v)
    ];

    public string? Id { get; set; }

    public string? Parent { get; set; }

    public string? Title { get; set; }

    public bool? IsDir { get; set; }

    public string? Album { get; set; }

    public string? Artist { get; set; }

    public int? Track { get; set; }

    public int? Year { get; set; }

    public string? Genre { get; set; }

    public string? CoverArt { get; set; }

    public int? Size { get; set; }

    public string? ContentType { get; set; }

    public string? Suffix { get; set; }

    public string? TranscodedContentType { get; set; }

    public string? TranscodedSuffix { get; set; }

    public string? Path { get; set; }
}
