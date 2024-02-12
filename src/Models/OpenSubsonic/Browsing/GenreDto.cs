using System.ComponentModel.DataAnnotations;
using System.Xml;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>A genre.</summary>
public sealed class GenreDto() : SubsonicContent<GenreDto>(
    "genres", "genre", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<GenreDto>> _ConvertAttributeHints = [
        new IntConvertHint<GenreDto>("songCount", m => m.SongCount, (m, v) => m.SongCount = v),
        new IntConvertHint<GenreDto>("albumCount", m => m.AlbumCount, (m, v) => m.AlbumCount = v)
    ];

    /// <summary>Genre song count</summary>
    [Required]
    public int? SongCount { get; set; }

    /// <summary>Genre album count</summary>
    [Required]
    public int? AlbumCount { get; set; }

    /// <summary>Genre name</summary>
    [Required]
    public string? Value { get; set; }

    /// <inheritdoc/>
    public override void ReadXml(XmlReader reader)
    {
        Value = XmlHintConverter.FromXml(reader, this, AttributeHints, ElementHints);
    }

    /// <inheritdoc/>
    public override void WriteXml(XmlWriter writer)
    {
        XmlHintConverter.ToXml(writer, this, AttributeHints, ElementHints);
        if (Value != null)
        {
            writer.WriteValue(Value);
        }
    }
}
