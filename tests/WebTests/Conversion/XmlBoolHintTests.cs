using System;
using JitterbugMusicServer.Web.Conversion;

namespace JitterbugMusicServer.WebTests.Conversion;

public class XmlBoolHintTests : BaseXmlHintTests<XmlBoolHintTests, bool?>
{
    protected override XmlHint<XmlBoolHintTests> CreateHint(string name,
        Func<XmlBoolHintTests, bool?> getter, Action<XmlBoolHintTests, bool?> setter)
    {
        return new XmlBoolHint<XmlBoolHintTests>(name, getter, setter);
    }
}