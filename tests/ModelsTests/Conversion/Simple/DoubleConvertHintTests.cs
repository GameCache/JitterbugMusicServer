using System;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.ModelsTests.Conversion.Simple;

public class DoubleConvertHintTests : BaseConvertHintTests<DoubleConvertHintTests, double?>
{
    protected override IConvertHint<DoubleConvertHintTests> CreateHint(string name,
        Func<DoubleConvertHintTests, double?> getter, Action<DoubleConvertHintTests, double?> setter)
    {
        return new DoubleConvertHint<DoubleConvertHintTests>(name, getter, setter);
    }
}
