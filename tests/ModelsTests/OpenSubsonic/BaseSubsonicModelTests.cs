using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.ModelsTests.Conversion;
using System.Text.Json;
using Xunit;

namespace JitterbugMusic.ModelsTests.OpenSubsonic;

public abstract class BaseSubsonicModelTests<T> where T : new()
{
    protected internal virtual T FixModel(T original)
    {
        return original;
    }

    [Theory, RandomData]
    internal void SerializesToJson(T original)
    {
        original = FixModel(original);
        JsonSerializer.Serialize(original).Assert().IsNot(null);
    }

    [Theory, RandomData]
    internal void RoundTripsViaJson(T original)
    {
        original = FixModel(original);
        ConvertTester.JsonTrip(original);
    }

    [Theory, RandomData]
    internal void RoundTripsViaXml(T original)
    {
        original = FixModel(original);
        ConvertTester.XmlTrip(original);
    }

    [Fact]
    internal virtual void RoundTripsDefaultsViaXml()
    {
        ConvertTester.XmlTrip(new T());
    }
}
