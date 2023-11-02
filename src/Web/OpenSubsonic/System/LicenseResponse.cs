using System.Xml.Serialization;

namespace JitterbugMusicServer.Web.OpenSubsonic.System;

/// <summary>Response with the user's license status.</summary>
[XmlRoot("subsonic-response", Namespace = "http://subsonic.org/restapi")]
public sealed class LicenseResponse : SubsonicResponse
{
    /// <summary><inheritdoc cref="LicenseModel"/></summary>
    [XmlElement("license")]
    public LicenseModel? License { get; set; }
}