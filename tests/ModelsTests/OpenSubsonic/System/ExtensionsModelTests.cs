using System.Linq;
using JitterbugMusic.Models.OpenSubsonic.System;

namespace JitterbugMusic.ModelsTests.OpenSubsonic.System;

public class ExtensionsModelTests : BaseSubsonicModelTests<ExtensionsModel>
{
    protected internal override ExtensionsModel FixModel(ExtensionsModel original)
    {
        original.OpenSubsonicExtensions = original
            .OpenSubsonicExtensions
            .Select(m => new ExtensionModelTests().FixModel(m))
            .ToList();
        return original;
    }
}