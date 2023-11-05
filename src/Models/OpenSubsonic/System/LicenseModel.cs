using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.System;

/// <summary>A user's license status.</summary>
public sealed class LicenseModel() : SubsonicContent<LicenseModel>("license", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<LicenseModel>> _ConvertAttributeHints = [
        new BoolConvertHint<LicenseModel>("valid", m => m.Valid, (m, v) => m.Valid = v ?? false),
        new StringConvertHint<LicenseModel>("email", m => m.Email, (m, v) => m.Email = v),
        new DateTimeConvertHint<LicenseModel>("licenseExpires", m => m.LicenseExpires, (m, v) => m.LicenseExpires = v),
        new DateTimeConvertHint<LicenseModel>("trialExpires", m => m.TrialExpires, (m, v) => m.TrialExpires = v),
    ];

    /// <summary>If the license is useable.</summary>
    public bool Valid { get; set; } = true;

    /// <summary>Related user's email.</summary>
    public string? Email { get; set; }

    /// <summary>Date for the license end. [ISO 8601]</summary>
    public DateTime? LicenseExpires { get; set; }

    /// <summary>Date for the trial end. [ISO 8601]</summary>
    public DateTime? TrialExpires { get; set; }
}
