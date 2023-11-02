using System;
using JitterbugMusicServer.Web.Conversion;

namespace JitterbugMusicServer.WebTests.Conversion;

public class XmlStringHintTests : BaseXmlHintTests<XmlStringHintTests, string>
{
    protected override XmlHint<XmlStringHintTests> CreateHint(string name,
        Func<XmlStringHintTests, string?> getter, Action<XmlStringHintTests, string?> setter)
    {
        return new XmlStringHint<XmlStringHintTests>(name, getter, setter);
    }
}