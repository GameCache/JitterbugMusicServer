using JitterbugMusic.Models.Conversion;

namespace JitterbugMusic.Models.OpenSubsonic;

/// <summary>Response with content from OpenSubsonic endpoints.</summary>
/// <param name="groupingHintName"><inheritdoc cref="GroupingHintName" path="/summary"/></param>
/// <param name="elementHintName"><inheritdoc cref="ElementHintName" path="/summary"/></param>
/// <param name="attributeHints"><inheritdoc cref="XmlHintSerializable{T}.AttributeHints" path="/summary"/></param>
/// <param name="elementHints"><inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/></param>
public abstract class SubsonicContent<T>(string? groupingHintName, string elementHintName,
        IEnumerable<IConvertHint<T>>? attributeHints, IEnumerable<IConvertHint<T>>? elementHints)
    : XmlHintSerializable<T>(attributeHints, elementHints) where T : SubsonicContent<T>
{
    /// <summary>Hint name identifier used to group the collection of this class.</summary>
    protected internal string? GroupingHintName { get; } = groupingHintName;

    /// <summary>Hint name identifier used for serialization of this class.</summary>
    protected internal string ElementHintName { get; } = elementHintName;

    /// <inheritdoc cref="SubsonicContent{T}"/>
    protected SubsonicContent(string elementHintName,
        IEnumerable<IConvertHint<T>>? attributeHints, IEnumerable<IConvertHint<T>>? elementHints)
        : this(null, elementHintName, attributeHints, elementHints) { }
}