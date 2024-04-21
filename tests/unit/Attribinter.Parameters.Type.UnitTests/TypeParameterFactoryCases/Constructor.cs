namespace Attribinter.Parameters.TypeParameterFactoryCases;

using Xunit;

public sealed class Constructor
{
    private static TypeParameterFactory Target() => new();

    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.NotNull(result);
    }
}
