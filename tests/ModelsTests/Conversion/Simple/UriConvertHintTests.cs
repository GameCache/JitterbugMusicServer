using System;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Simple;

namespace JitterbugMusic.ModelsTests.Conversion.Simple;

public class UriConvertHintTests : BaseConvertHintTests<UriConvertHintTests, Uri?>
{
    protected override IConvertHint<UriConvertHintTests> CreateHint(string name,
        Func<UriConvertHintTests, Uri?> getter, Action<UriConvertHintTests, Uri?> setter)
    {
        return new UriConvertHint<UriConvertHintTests>(name, getter, setter);
    }
}
