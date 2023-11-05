using System.Linq;
using JitterbugMusic.Models.OpenSubsonic.System;

namespace JitterbugMusic.ModelsTests.OpenSubsonic.System;

public class ExtensionModelTests : BaseSubsonicModelTests<ExtensionModel>
{
    protected internal override ExtensionModel FixModel(ExtensionModel original)
    {
        original.Versions = original.Versions.ToList();
        return original;
    }
}
