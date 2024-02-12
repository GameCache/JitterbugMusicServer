﻿using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Models.OpenSubsonic.Browsing;
using Xunit;

namespace JitterbugMusic.ModelsTests.OpenSubsonic.Browsing;

public class IndexesDtoTests : BaseSubsonicDtoTests<IndexesDto>
{
    [Theory, RandomData]
    internal void CombinedIgnoredArticles_NullSafe(IndexesDto original)
    {
        original.CombinedIgnoredArticles = null;
        original.CombinedIgnoredArticles.Assert().Is(null);
    }
}
