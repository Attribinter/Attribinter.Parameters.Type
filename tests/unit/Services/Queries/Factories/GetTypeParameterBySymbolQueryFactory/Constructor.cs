namespace Paraminter.Parameters.Type.Queries.Factories;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private static GetTypeParameterBySymbolQueryFactory Target() => new();
}
