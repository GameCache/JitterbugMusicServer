using System.ComponentModel.DataAnnotations;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Nested;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>A contributor artist for a song or an album</summary>
public sealed class ContributorDto() : SubsonicContent<ContributorDto>(
    "contributors", "contributor", _ConvertAttributeHints, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ContributorDto>> _ConvertAttributeHints = [
        new StringConvertHint<ContributorDto>("role", m => m.Role, (m, v) => m.Role = v),
        new StringConvertHint<ContributorDto>("subRole", m => m.SubRole, (m, v) => m.SubRole = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ContributorDto>> _ConvertElementHints = [
        new NestedConvertHint<ContributorDto, ArtistId3Dto>("artist", m => m.Artist, (m, v) => m.Artist = v)
    ];

    /// <summary>The contributor role.</summary>
    [Required]
    public string? Role { get; set; } = "";

    /// <summary>The subRole for roles that may require it. Ex: The instrument for the performer role (TMCL/performer tags). Note: For consistency between different tag formats, the TIPL sub roles should be directly exposed in the role field.</summary>
    public string? SubRole { get; set; } = "";

    /// <summary>The artist taking on the role. (Note: Only the required ArtistID3 fields should be returned by default)</summary>
    [Required]
    public ArtistId3Dto? Artist { get; set; } = new ArtistId3Dto();
}