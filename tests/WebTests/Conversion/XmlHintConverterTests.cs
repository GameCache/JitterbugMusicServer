using CreateAndFake;
using CreateAndFake.Fluent;
using Xunit;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using JitterbugMusicServer.Web.Conversion;
using System;
using JitterbugMusicServer.Web.OpenSubsonic.System;

namespace JitterbugMusicServer.WebTests.Conversion;

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
        XmlSerializer serializer = new(typeof(LicenseModel));

        string xml = "<LicenseModel><a><b/></a><![CDATA[stuff]]><c/></LicenseModel>";

        using (StringReader text = new(xml))
        using (XmlReader reader = XmlReader.Create(text))
        {
            serializer.Deserialize(reader).Assert().IsNot(null);
        }
    }
}