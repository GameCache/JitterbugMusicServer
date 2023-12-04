using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.MediaRetrieval;

/// <summary>MusicFolder.</summary>
public sealed class LyricsDto() : SubsonicContent<LyricsDto>(
    null, "lyrics", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<LyricsDto>> _ConvertAttributeHints = [
        new StringConvertHint<LyricsDto>("value", m => m.Value, (m, v) => m.Value = v),
        new StringConvertHint<LyricsDto>("artist", m => m.Artist, (m, v) => m.Artist = v),
        new StringConvertHint<LyricsDto>("title", m => m.Title, (m, v) => m.Title = v)
    ];

    /// <summary>The lyrics</summary>
    public string? Value { get; set; }

    /// <summary>The artist name</summary>
    public string? Artist { get; set; }

    /// <summary>The song title</summary>
    public string? Title { get; set; }
}