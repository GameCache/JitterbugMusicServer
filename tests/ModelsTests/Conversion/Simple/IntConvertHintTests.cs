using System;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.ModelsTests.Conversion.Simple;

public class IntConvertHintTests : BaseConvertHintTests<IntConvertHintTests, int?>
{
    protected override IConvertHint<IntConvertHintTests> CreateHint(string name,
        Func<IntConvertHintTests, int?> getter, Action<IntConvertHintTests, int?> setter)
    {
        return new IntConvertHint<IntConvertHintTests>(name, getter, setter);
    }
}