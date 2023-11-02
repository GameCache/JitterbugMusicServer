using System;
using JitterbugMusicServer.Web.Conversion;

namespace JitterbugMusicServer.WebTests.Conversion;

public class XmlDateTimeHintTests : BaseXmlHintTests<XmlDateTimeHintTests, DateTime?>
{
    protected override XmlHint<XmlDateTimeHintTests> CreateHint(string name,
    Func<XmlDateTimeHintTests, DateTime?> getter, Action<XmlDateTimeHintTests, DateTime?> setter)
    {
        return new XmlDateTimeHint<XmlDateTimeHintTests>(name, getter, setter);
    }
}