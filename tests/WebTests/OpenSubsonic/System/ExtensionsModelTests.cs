using System.Linq;
using JitterbugMusicServer.Web.OpenSubsonic.System;

namespace JitterbugMusicServer.WebTests.OpenSubsonic.System;

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