using System.Text.Json.Serialization;

namespace JitterbugMusicServer.Web.OpenSubsonic;

/// <summary>Wraps the model to match expected OpenSubsonic json format.</summary>
/// <param name="content"><inheritdoc cref="Content" path="/summary"/></param>
public sealed class ResponseJsonWrapper<T>(T? content) where T : SubsonicResponse
{
    /// <summary>Response content.</summary>
    [JsonPropertyName("subsonic-response")]
    public T? Content { get; set; } = content;

    /// <inheritdoc cref="ResponseJsonWrapper{T}"/>
    public ResponseJsonWrapper() : this(null) { }
}