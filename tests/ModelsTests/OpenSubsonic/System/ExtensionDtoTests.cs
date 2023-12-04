using System.Linq;
using JitterbugMusic.Models.OpenSubsonic.System;

namespace JitterbugMusic.ModelsTests.OpenSubsonic.System;

public class ExtensionDtoTests : BaseSubsonicDtoTests<ExtensionDto>
{
    protected internal override ExtensionDto FixModel(ExtensionDto original)
    {
        original.Versions = original.Versions.ToList();
        return original;
    }
}
