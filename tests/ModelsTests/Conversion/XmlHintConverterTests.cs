using CreateAndFake;
using CreateAndFake.Fluent;
using Xunit;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using JitterbugMusic.Models.Conversion;
using System;
using JitterbugMusic.Models.OpenSubsonic.System;

namespace JitterbugMusic.ModelsTests.Conversion;

public class XmlHintConverterTests
{
    [Fact]
    internal void FromXml_NullReaderGuard()
    {
        Tools.Asserter.Throws<ArgumentNullException>(() => XmlHintConverter.FromXml(null, this, null, null));
    }

    [Fact]
    internal void FromXml_IgnoresRandomNodes()
    {
        XmlSerializer serializer = new(typeof(LicenseDto));

        string xml = "<LicenseDto><a><b/></a><![CDATA[stuff]]><c/></LicenseDto>";

        using (StringReader text = new(xml))
        using (XmlReader reader = XmlReader.Create(text))
        {
            serializer.Deserialize(reader).Assert().IsNot(null);
        }
    }
}