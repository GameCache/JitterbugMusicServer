using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.ModelsTests.Conversion;
using System.Text.Json;
using Xunit;

namespace JitterbugMusic.ModelsTests.OpenSubsonic;

public abstract class BaseSubsonicDtoTests<T> where T : XmlHintSerializable<T>, new()
{
    [Theory, RandomData]
    internal void SerializesToJson(T original)
    {
        JsonSerializer.Serialize(original).Assert().IsNot(null);
    }

    [Theory, RandomData]
    internal void RoundTripsViaJson(T original)
    {
        ConvertTester.JsonTrip(original);
    }

    [Theory, RandomData]
    internal void RoundTripsViaXml(T original)
    {
        ConvertTester.XmlTrip(original);
    }

    [Fact]
    internal virtual void RoundTripsDefaultsViaXml()
    {
        ConvertTester.XmlTrip(new T());
    }

    [Theory, RandomData]
    internal void GetSchema_IsNull(T model)
    {
        model.GetSchema().Assert().Is(null);
    }
}
