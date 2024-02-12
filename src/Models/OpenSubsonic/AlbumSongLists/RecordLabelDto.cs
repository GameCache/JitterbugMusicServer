using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.AlbumSongLists;

/// <summary>A record label for an album.</summary>
public sealed class RecordLabelDto() : SubsonicContent<RecordLabelDto>(
    "recordLabels", "recordLabel", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<RecordLabelDto>> _ConvertAttributeHints = [
        new StringConvertHint<RecordLabelDto>("name", m => m.Name, (m, v) => m.Name = v)
    ];

    /// <summary>The record label name.</summary>
    [Required]
    public string? Name { get; set; } = "";
}
