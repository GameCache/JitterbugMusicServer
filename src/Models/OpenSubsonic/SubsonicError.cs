using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.Models.OpenSubsonic;

/// <summary>Encountered error.</summary>
public sealed class SubsonicError() : XmlHintSerializable<SubsonicError>(_ConvertAttributeHints, null)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<SubsonicError>> _ConvertAttributeHints = [
        new IntConvertHint<SubsonicError>("code", m => m.Code, (m, v) => m.Code = v ?? 0),
        new StringConvertHint<SubsonicError>("message", m => m.Message, (m, v) => m.Message = v),
    ];

    /// <summary>The error code.</summary>
    public int Code { get; set; }

    /// <summary>The optional error message.</summary>
    public string? Message { get; set; }
}