using System;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.ModelsTests.Conversion.Simple;

public class BoolConvertHintTests : BaseConvertHintTests<BoolConvertHintTests, bool?>
{
    protected override IConvertHint<BoolConvertHintTests> CreateHint(string name,
        Func<BoolConvertHintTests, bool?> getter, Action<BoolConvertHintTests, bool?> setter)
    {
        return new BoolConvertHint<BoolConvertHintTests>(name, getter, setter);
    }
}