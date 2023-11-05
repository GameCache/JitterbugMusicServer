using System.Linq;
using JitterbugMusicServer.Web.OpenSubsonic.System;

namespace JitterbugMusicServer.WebTests.OpenSubsonic.System;

public class ExtensionModelTests : BaseSubsonicModelTests<ExtensionModel>
{
    protected internal override ExtensionModel FixModel(ExtensionModel original)
    {
        original.Versions = original.Versions.ToList();
        return original;
    }
}
