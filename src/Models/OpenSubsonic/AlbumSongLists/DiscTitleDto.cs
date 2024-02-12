using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.AlbumSongLists;

/// <summary>A date for a media item that may be just a year, or year-month, or full date.</summary>
public sealed class DiscTitleDto() : SubsonicContent<DiscTitleDto>(
    "itemDates", "itemDate", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<DiscTitleDto>> _ConvertAttributeHints = [
        new IntConvertHint<DiscTitleDto>("year", m => m.Disc, (m, v) => m.Disc = v),
        new StringConvertHint<DiscTitleDto>("month", m => m.Title, (m, v) => m.Title = v)
    ];

    /// <summary>The disc number.</summary>
    [Required]
    public int? Disc { get; set; } = 0;

    /// <summary>The name of the disc.</summary>
    [Required]
    public string? Title { get; set; } = "";
}
