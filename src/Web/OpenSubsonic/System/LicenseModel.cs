using System.Xml.Serialization;
using JitterbugMusicServer.Web.Conversion;

namespace JitterbugMusicServer.Web.OpenSubsonic.System;

/// <summary>A user's license status.</summary>
public sealed class LicenseModel : XmlHintSerializable<LicenseModel>, IXmlSerializable
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<XmlHint<LicenseModel>> _ConvertAttributeHints = [
        new XmlBoolHint<LicenseModel>("valid", m => m.Valid, (m, v) => m.Valid = v ?? false),
        new XmlStringHint<LicenseModel>("email", m => m.Email, (m, v) => m.Email = v),
        new XmlDateTimeHint<LicenseModel>("licenseExpires", m => m.LicenseExpires, (m, v) => m.LicenseExpires = v),
        new XmlDateTimeHint<LicenseModel>("trialExpires", m => m.TrialExpires, (m, v) => m.TrialExpires = v),
    ];

    /// <inheritdoc cref="LicenseModel"/>
    public LicenseModel() : base(_ConvertAttributeHints, null) { }

    /// <summary>If the license is useable.</summary>
    public bool Valid { get; set; } = true;

    /// <summary>Related user's email.</summary>
    public string? Email { get; set; }

    /// <summary>Date for the license end. [ISO 8601]</summary>
    public DateTime? LicenseExpires { get; set; }

    /// <summary>Date for the trial end. [ISO 8601]</summary>
    public DateTime? TrialExpires { get; set; }
}
