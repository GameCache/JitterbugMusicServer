using System;
using JitterbugMusicServer.Web.Conversion;
using JitterbugMusicServer.Web.Conversion.Simple;

namespace JitterbugMusicServer.WebTests.Conversion.Simple;

public class DateTimeConvertHintTests : BaseConvertHintTests<DateTimeConvertHintTests, DateTime?>
{
    protected override IConvertHint<DateTimeConvertHintTests> CreateHint(string name,
    Func<DateTimeConvertHintTests, DateTime?> getter, Action<DateTimeConvertHintTests, DateTime?> setter)
    {
        return new DateTimeConvertHint<DateTimeConvertHintTests>(name, getter, setter);
    }
}