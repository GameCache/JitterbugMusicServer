using System;
using JitterbugMusicServer.Web.Conversion;
using JitterbugMusicServer.Web.Conversion.Simple;

namespace JitterbugMusicServer.WebTests.Conversion.Simple;

public class IntConvertHintTests : BaseConvertHintTests<IntConvertHintTests, int?>
{
    protected override IConvertHint<IntConvertHintTests> CreateHint(string name,
        Func<IntConvertHintTests, int?> getter, Action<IntConvertHintTests, int?> setter)
    {
        return new IntConvertHint<IntConvertHintTests>(name, getter, setter);
    }
}