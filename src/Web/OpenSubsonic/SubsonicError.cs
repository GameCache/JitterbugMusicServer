using System.Xml;
using System.Xml.Serialization;

namespace JitterbugMusicServer.Web.OpenSubsonic;

/// <summary>Encountered error.</summary>
public sealed class SubsonicError
{
    /// <summary>The error code.</summary>
    [XmlAttribute("code")]
    public int Code { get; set; }

    /// <summary>The optional error message.</summary>
    [XmlAttribute("message")]
    public string? Message { get; set; }
}