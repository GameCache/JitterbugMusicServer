using System.Xml.Serialization;

namespace JitterbugMusicServer.Web.OpenSubsonic.System;

#pragma warning disable CA1819

/// <summary>Response with the supported OpenSubsonic API extensions.</summary>
/// <param name="extensions"><inheritdoc cref="OpenSubsonicExtensions" path="/summary"/></param>
[XmlRoot("subsonic-response", Namespace = "http://subsonic.org/restapi")]
public sealed class ExtensionsResponse(IEnumerable<ExtensionModel> extensions) : SubsonicResponse
{
    /// <summary>Each supported extension.</summary>
    [XmlArray("openSubsonicExtensions"), XmlArrayItem("openSubsonicExtension")]
    public ExtensionModel[] OpenSubsonicExtensions { get; set; } = extensions.ToArray();

    /// <inheritdoc cref="ExtensionsResponse"/>
    public ExtensionsResponse() : this(Array.Empty<ExtensionModel>()) { }
}

#pragma warning restore CA1819
