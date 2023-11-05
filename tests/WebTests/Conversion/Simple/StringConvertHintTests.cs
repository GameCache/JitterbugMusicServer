using System;
using JitterbugMusicServer.Web.Conversion;
using JitterbugMusicServer.Web.Conversion.Simple;

namespace JitterbugMusicServer.WebTests.Conversion.Simple;

public class StringConvertHintTests : BaseConvertHintTests<StringConvertHintTests, string>
{
    protected override IConvertHint<StringConvertHintTests> CreateHint(string name,
        Func<StringConvertHintTests, string?> getter, Action<StringConvertHintTests, string?> setter)
    {
        return new StringConvertHint<StringConvertHintTests>(name, getter, setter);
    }
}