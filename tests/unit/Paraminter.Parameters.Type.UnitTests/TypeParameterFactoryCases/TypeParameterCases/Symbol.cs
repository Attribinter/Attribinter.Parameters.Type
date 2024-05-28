namespace Paraminter.Parameters.TypeParameterFactoryCases.TypeParameterCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class Symbol
{
    private readonly IParameterFixture Fixture = ParameterFixtureFactory.Create();

    [Fact]
    public void ReturnsSymbol()
    {
        var result = Target();

        Assert.Same(Fixture.SymbolMock.Object, result);
    }

    private ITypeParameterSymbol Target() => Fixture.Sut.Symbol;
}
