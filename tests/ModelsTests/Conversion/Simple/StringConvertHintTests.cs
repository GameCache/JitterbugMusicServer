using System;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.ModelsTests.Conversion.Simple;

public class StringConvertHintTests : BaseConvertHintTests<StringConvertHintTests, string>
{
    protected override IConvertHint<StringConvertHintTests> CreateHint(string name,
        Func<StringConvertHintTests, string?> getter, Action<StringConvertHintTests, string?> setter)
    {
        return new StringConvertHint<StringConvertHintTests>(name, getter, setter);
    }
}