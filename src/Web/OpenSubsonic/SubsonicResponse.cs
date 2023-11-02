using System.Xml;
using System.Xml.Serialization;

namespace JitterbugMusicServer.Web.OpenSubsonic;

/// <summary>Base status response from OpenSubsonic endpoints.</summary>
[XmlRoot("subsonic-response", Namespace = "http://subsonic.org/restapi")]
public class SubsonicResponse
{
    /// <summary>The command result: "ok" or "failed".</summary>
    [XmlAttribute("status")]
    public string Status { get; set; } = "ok";

    /// <summary>The server supported Subsonic API version.</summary>
    [XmlAttribute("version")]
    public string Version { get; set; } = "1.16.1";

    /// <summary>The server actual name.</summary>
    [XmlAttribute("type")]
    public string Type { get; set; } = "JitterbugMusicServer";

    /// <summary>The server actual version.</summary>
    [XmlAttribute("serverVersion")]
    public string ServerVersion { get; set; } = "0.0.0";

    /// <summary>Must return true if the server supports OpenSubsonic API v1.</summary>
    [XmlAttribute("openSubsonic")]
    public bool OpenSubsonic { get; set; } = true;

    /// <summary>Error encountered.</summary>
    [XmlElement("error")]
    public SubsonicError? Error { get; set; }
}