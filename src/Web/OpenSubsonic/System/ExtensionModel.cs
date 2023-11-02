using System.Xml.Serialization;
using System.Xml;

namespace JitterbugMusicServer.Web.OpenSubsonic.System;

#pragma warning disable CA1819

/// <summary>A supported OpenSubsonic API extension.</summary>
/// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
/// <param name="versions"><inheritdoc cref="Versions" path="/summary"/></param>
public sealed class ExtensionModel(string name, IEnumerable<int> versions)
{
    /// <summary>Name of the extension.</summary>
    [XmlAttribute("name")]
    public string Name { get; set; } = name;

    /// <summary>Supported versions of the extension.</summary>
    [XmlElement("version")]
    public int[] Versions { get; set; } = versions.ToArray();

    /// <inheritdoc cref="ExtensionModel"/>
    public ExtensionModel() : this("", Array.Empty<int>()) { }
}

#pragma warning restore CA1819
