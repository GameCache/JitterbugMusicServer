using JitterbugMusicServer.Web.Conversion;

namespace JitterbugMusicServer.Web.OpenSubsonic;

/// <summary>Response with content from OpenSubsonic endpoints.</summary>
/// <param name="elementHintName"><inheritdoc cref="ElementHintName" path="/summary"/></param>
/// <param name="attributeHints"><inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/></param>
/// <param name="elementHints"><inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/></param>
public abstract class SubsonicContent<T>(string elementHintName,
        IEnumerable<IConvertHint<T>>? attributeHints, IEnumerable<IConvertHint<T>>? elementHints)
    : XmlHintSerializable<T>(attributeHints, elementHints) where T : SubsonicContent<T>
{
    /// <summary>Hint name identifier used for serialization of this class.</summary>
    protected internal string ElementHintName { get; } = elementHintName;
}