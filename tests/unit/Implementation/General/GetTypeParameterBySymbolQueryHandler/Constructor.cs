namespace Paraminter.Parameters;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullTypeParameterFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsFactory()
    {
        var result = Target(Mock.Of<ITypeParameterFactory>());

        Assert.NotNull(result);
    }

    private static GetTypeParameterBySymbolQueryHandler Target(
        ITypeParameterFactory typeParameterFactory)
    {
        return new GetTypeParameterBySymbolQueryHandler(typeParameterFactory);
    }
}
