namespace Paraminter.Parameters.Type.Queries.Factories;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class Create()
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullSymbol_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidSymbol_ReturnsQuery()
    {
        var result = Target(Mock.Of<ITypeParameterSymbol>());

        Assert.NotNull(result);
    }

    private IGetTypeParameterBySymbolQuery Target(
        ITypeParameterSymbol symbol)
    {
        return Fixture.Sut.Create(symbol);
    }
}
