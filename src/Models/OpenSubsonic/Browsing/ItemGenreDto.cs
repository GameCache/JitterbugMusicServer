using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>A genre returned in list of genres for an item.</summary>
public sealed class ItemGenreDto() : SubsonicContent<ItemGenreDto>(
    "genres", "genre", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ItemGenreDto>> _ConvertAttributeHints = [
        new StringConvertHint<ItemGenreDto>("name", m => m.Name, (m, v) => m.Name = v)
    ];

    /// <summary>Genre name</summary>
    [Required]
    public string? Name { get; set; } = "";
}