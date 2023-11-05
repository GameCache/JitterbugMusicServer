using JitterbugMusicServer.Web.Conversion;
using JitterbugMusicServer.Web.Conversion.Nested;

namespace JitterbugMusicServer.Web.OpenSubsonic.System;

/// <summary>Response with the supported OpenSubsonic API extensions.</summary>
public sealed class ExtensionsModel()
    : SubsonicContent<ExtensionsModel>("openSubsonicExtensions", null, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ExtensionsModel>> _ConvertElementHints = [
        new NestedSeriesConvertHint<ExtensionsModel, ExtensionModel>(null, "openSubsonicExtension",
            m => m.OpenSubsonicExtensions, (m, v) => m.OpenSubsonicExtensions = v)
    ];

    /// <summary>Each supported extension.</summary>
    public IEnumerable<ExtensionModel>? OpenSubsonicExtensions { get; set; }
}
