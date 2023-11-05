using System;
using System.Collections.Generic;
using System.Linq;
using JitterbugMusicServer.Web.Conversion.Series;

namespace JitterbugMusicServer.WebTests.Conversion.Series;

public class IntSeriesConvertHintTests : BaseSeriesConvertHint<IntSeriesConvertHintTests, IEnumerable<int>>
{
    protected override ISeriesConvertHint<IntSeriesConvertHintTests> CreateSeriesHint(
        string? seriesName, string itemName,
        Func<IntSeriesConvertHintTests, IEnumerable<int>?> getter,
        Action<IntSeriesConvertHintTests, IEnumerable<int>?> setter)
    {
        return new IntSeriesConvertHint<IntSeriesConvertHintTests>(seriesName, itemName, getter, setter);
    }

    protected override IEnumerable<int> FixModel(IEnumerable<int> original)
    {
        return original.ToList();
    }
}