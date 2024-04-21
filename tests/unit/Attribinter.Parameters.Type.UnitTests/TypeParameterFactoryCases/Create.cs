namespace Attribinter.Parameters.TypeParameterFactoryCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class Create
{
    private ITypeParameter Target(ITypeParameterSymbol symbol) => Fixture.Sut.Create(symbol);

    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();

    [Fact]
    public void NullSymbol_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidSymbol_ReturnsTypeParameter()
    {
        var result = Target(Mock.Of<ITypeParameterSymbol>());

        Assert.NotNull(result);
    }
}
