using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;
using JitterbugMusic.Models.Conversion.Nested;

namespace JitterbugMusic.Models.OpenSubsonic;

#pragma warning disable CA2227

/// <summary>Response with content from OpenSubsonic endpoints.</summary>
[XmlRoot("subsonic-response", Namespace = "http://subsonic.org/restapi")]
public class SubsonicResponse<T> : IXmlSerializable where T : SubsonicContent<T>, new()
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<SubsonicResponse<T>>> _ConvertAttributeHints = [
        new StringConvertHint<SubsonicResponse<T>>("status", m => m.Status, (m, v) => m.Status = v),
        new StringConvertHint<SubsonicResponse<T>>("version", m => m.Version, (m, v) => m.Version = v),
        new StringConvertHint<SubsonicResponse<T>>("type", m => m.Type, (m, v) => m.Type = v),
        new StringConvertHint<SubsonicResponse<T>>("serverVersion", m => m.ServerVersion, (m, v) => m.ServerVersion = v),
        new BoolConvertHint<SubsonicResponse<T>>("openSubsonic", m => m.OpenSubsonic, (m, v) => m.OpenSubsonic = v)
    ];

    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<SubsonicResponse<T>>> _ConvertElementHints = [
        new NestedConvertHint<SubsonicResponse<T>, T>(new T().ElementHintName, m => m.Content, (m, v) => m.Content = v),
        new NestedConvertHint<SubsonicResponse<T>, SubsonicError>("error", m => m.Error, (m, v) => m.Error = v)
    ];

    /// <summary>Handles json conversion.</summary>
    [JsonPropertyName("subsonic-response")]
    public IDictionary<string, dynamic?>? JsonDataProvider
    {
        get => _ConvertAttributeHints
                .Concat(_ConvertElementHints)
                .Where(h => h.GetValueForJson(this) != null)
                .ToDictionary(h => h.Name, h => h.GetValueForJson(this));
        set
        {
            foreach (IConvertHint<SubsonicResponse<T>> hint in _ConvertElementHints.Concat(_ConvertAttributeHints))
            {
                if (value?.TryGetValue(hint.Name, out dynamic? item) ?? false)
                {
                    hint.SetValueForJson(this, item);
                }
                else
                {
                    hint.ResetToDefault(this);
                }
            }
        }
    }

    /// <summary>The command result: "ok" or "failed".</summary>
    [JsonIgnore]
    public string? Status { get; set; } = "ok";

    /// <summary>The server supported Subsonic API version.</summary>
    [JsonIgnore]
    public string? Version { get; set; } = "1.16.1";

    /// <summary>The server actual name.</summary>
    [JsonIgnore]
    public string? Type { get; set; } = "JitterbugMusicServer";

    /// <summary>The server actual version.</summary>
    [JsonIgnore]
    public string? ServerVersion { get; set; } = "0.0.0";

    /// <summary>Must return true if the server supports OpenSubsonic API v1.</summary>
    [JsonIgnore]
    public bool? OpenSubsonic { get; set; } = true;

    /// <summary>Error encountered.</summary>
    [JsonIgnore]
    public SubsonicError? Error { get; set; }

    /// <summary>Data result of the endpoint call.</summary>
    [JsonIgnore]
    public T? Content { get; set; }

    /// <inheritdoc/>
    public void ReadXml(XmlReader reader)
    {
        XmlHintConverter.FromXml(reader, this, _ConvertAttributeHints, _ConvertElementHints);
    }

    /// <inheritdoc/>
    public void WriteXml(XmlWriter writer)
    {
        XmlHintConverter.ToXml(writer, this, _ConvertAttributeHints, _ConvertElementHints);
    }

    /// <inheritdoc/>
    public XmlSchema? GetSchema()
    {
        return null;
    }
}

#pragma warning restore CA2227