using System;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.ModelsTests.Conversion.Simple;

public class LongConvertHintTests : BaseConvertHintTests<LongConvertHintTests, long?>
{
    protected override IConvertHint<LongConvertHintTests> CreateHint(string name,
        Func<LongConvertHintTests, long?> getter, Action<LongConvertHintTests, long?> setter)
    {
        return new LongConvertHint<LongConvertHintTests>(name, getter, setter);
    }
}