using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace JitterbugMusic.Models.Conversion;

/// <summary>Enables XML serialization via <see cref="IConvertHint{T}"/></summary>
/// <typeparam name="T">Type self-reference.</typeparam>
/// <param name="attributeHints"><inheritdoc cref="AttributeHints" path="/summary"/></param>
/// <param name="elementHints"><inheritdoc cref="ElementHints" path="/summary"/></param>
public abstract class XmlHintSerializable<T>(
    IEnumerable<IConvertHint<T>>? attributeHints, IEnumerable<IConvertHint<T>>? elementHints)
    : IXmlSerializable where T : XmlHintSerializable<T>
{
    /// <summary>Convert behavior for properties representing attributes.</summary>
    protected IEnumerable<IConvertHint<T>>? AttributeHints { get; } = attributeHints;

    /// <summary>Convert behavior for properties representing elements.</summary>
    protected IEnumerable<IConvertHint<T>>? ElementHints { get; } = elementHints;

    /// <inheritdoc/>
    public XmlSchema? GetSchema()
    {
        return null;
    }

    /// <inheritdoc/>
    public void ReadXml(XmlReader reader)
    {
        XmlHintConverter.FromXml(reader, (T)this, AttributeHints, ElementHints);
    }

    /// <inheritdoc/>
    public void WriteXml(XmlWriter writer)
    {
        XmlHintConverter.ToXml(writer, (T)this, AttributeHints, ElementHints);
    }
}
