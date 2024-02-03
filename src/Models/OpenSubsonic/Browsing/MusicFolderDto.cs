using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>MusicFolder.</summary>
public sealed class MusicFolderDto() : SubsonicContent<MusicFolderDto>(
    "musicFolders", "musicFolder", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<MusicFolderDto>> _ConvertAttributeHints = [
        new StringConvertHint<MusicFolderDto>("id", m => m.Id, (m, v) => m.Id = v),
        new StringConvertHint<MusicFolderDto>("name", m => m.Name, (m, v) => m.Name = v)
    ];

    /// <summary>The id</summary>
    [Required]
    public string? Id { get; set; }

    /// <summary>The folder name</summary>
    public string? Name { get; set; }
}