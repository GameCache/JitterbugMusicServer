using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>The replay gain data of a song.</summary>
public sealed class ReplayGainDto() : SubsonicContent<ReplayGainDto>(
    "replayGain", _ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<ReplayGainDto>> _ConvertAttributeHints = [
        new DoubleConvertHint<ReplayGainDto>("trackGain", m => m.TrackGain, (m, v) => m.TrackGain = v),
        new DoubleConvertHint<ReplayGainDto>("albumGain", m => m.AlbumGain, (m, v) => m.AlbumGain = v),
        new DoubleConvertHint<ReplayGainDto>("trackPeak", m => m.TrackPeak, (m, v) => m.TrackPeak = v),
        new DoubleConvertHint<ReplayGainDto>("albumPeak", m => m.AlbumPeak, (m, v) => m.AlbumPeak = v),
        new DoubleConvertHint<ReplayGainDto>("baseGain", m => m.BaseGain, (m, v) => m.BaseGain = v),
        new DoubleConvertHint<ReplayGainDto>("fallbackGain", m => m.FallbackGain, (m, v) => m.FallbackGain = v)
    ];

    /// <summary>The track replay gain value. (In Db)</summary>
    public double? TrackGain { get; set; }

    /// <summary>The album replay gain value. (In Db)</summary>
    public double? AlbumGain { get; set; }

    /// <summary>The track peak value. (Must be positive)</summary>
    public double? TrackPeak { get; set; }

    /// <summary>The album peak value. (Must be positive)</summary>
    public double? AlbumPeak { get; set; }

    /// <summary>The base gain value. (In Db) (Ogg Opus Output Gain for example)</summary>
    public double? BaseGain { get; set; }

    /// <summary>An optional fallback gain that clients should apply when the corresponding gain value is missing. (Can be computed from the tracks or exposed as an user setting.)</summary>
    public double? FallbackGain { get; set; }
}