using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Nested;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>Directory.</summary>
public sealed class DirectoryDto() : SubsonicContent<DirectoryDto>(
    "directory", _ConvertAttributeHints, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<DirectoryDto>> _ConvertAttributeHints = [
        new StringConvertHint<DirectoryDto>("id", m => m.Id, (m, v) => m.Id = v),
        new StringConvertHint<DirectoryDto>("parent", m => m.Parent, (m, v) => m.Parent = v),
        new StringConvertHint<DirectoryDto>("name", m => m.Name, (m, v) => m.Name = v),
        new DateTimeConvertHint<DirectoryDto>("starred", m => m.Starred, (m, v) => m.Starred = v),
        new IntConvertHint<DirectoryDto>("userRating", m => m.UserRating, (m, v) => m.UserRating = v),
        new DoubleConvertHint<DirectoryDto>("averageRating", m => m.AverageRating, (m, v) => m.AverageRating = v),
        new LongConvertHint<DirectoryDto>("playCount", m => m.PlayCount, (m, v) => m.PlayCount = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<DirectoryDto>> _ConvertElementHints = [
        new NestedSeriesConvertHint<DirectoryDto, ChildDto>(null, "child", m => m.Child, (m, v) => m.Child = v)
    ];

    /// <summary>The id</summary>
    [Required]
    public string? Id { get; set; }

    /// <summary>Parent item</summary>
    public string? Parent { get; set; }

    /// <summary>The directory name</summary>
    [Required]
    public string? Name { get; set; }

    /// <summary>Starred date [ISO 8601]</summary>
    public DateTime? Starred { get; set; }

    /// <summary>The user rating [1-5]</summary>
    public int? UserRating { get; set; }

    /// <summary>The average rating [1.0-5.0]</summary>
    public double? AverageRating { get; set; }

    /// <summary>The play count</summary>
    public long? PlayCount { get; set; }

    /// <summary>The directory content</summary>
    public IEnumerable<ChildDto>? Child { get; set; }
}