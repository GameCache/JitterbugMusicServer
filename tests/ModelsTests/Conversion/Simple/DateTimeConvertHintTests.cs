using System;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.ModelsTests.Conversion.Simple;

public class DateTimeConvertHintTests : BaseConvertHintTests<DateTimeConvertHintTests, DateTime?>
{
    protected override IConvertHint<DateTimeConvertHintTests> CreateHint(string name,
    Func<DateTimeConvertHintTests, DateTime?> getter, Action<DateTimeConvertHintTests, DateTime?> setter)
    {
        return new DateTimeConvertHint<DateTimeConvertHintTests>(name, getter, setter);
    }
}