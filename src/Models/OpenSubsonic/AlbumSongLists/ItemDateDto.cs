using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.AlbumSongLists;

/// <summary>A date for a media item that may be just a year, or year-month, or full date.</summary>
public sealed class ItemDateDto() : SubsonicContent<ItemDateDto>(
    "itemDates", "itemDate", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ItemDateDto>> _ConvertAttributeHints = [
        new IntConvertHint<ItemDateDto>("year", m => m.Year, (m, v) => m.Year = v),
        new IntConvertHint<ItemDateDto>("month", m => m.Month, (m, v) => m.Month = v),
        new IntConvertHint<ItemDateDto>("day", m => m.Day, (m, v) => m.Day = v)
    ];

    /// <summary>The year</summary>
    [Required]
    public int? Year { get; set; } = 0;

    /// <summary>The month (1-12)</summary>
    public int? Month { get; set; } = 0;

    /// <summary>The day (1-31)</summary>
    public int? Day { get; set; } = 0;
}
