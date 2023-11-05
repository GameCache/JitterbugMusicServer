using System;
using JitterbugMusicServer.Web.Conversion;
using JitterbugMusicServer.Web.Conversion.Simple;

namespace JitterbugMusicServer.WebTests.Conversion.Simple;

public class BoolConvertHintTests : BaseConvertHintTests<BoolConvertHintTests, bool?>
{
    protected override IConvertHint<BoolConvertHintTests> CreateHint(string name,
        Func<BoolConvertHintTests, bool?> getter, Action<BoolConvertHintTests, bool?> setter)
    {
        return new BoolConvertHint<BoolConvertHintTests>(name, getter, setter);
    }
}