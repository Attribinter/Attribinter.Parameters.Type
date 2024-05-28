namespace Paraminter.Parameters.TypeParameterFactoryCases.TypeParameterCases;

using Microsoft.CodeAnalysis;

using Moq;

internal static class ParameterFixtureFactory
{
    public static IParameterFixture Create()
    {
        Mock<ITypeParameterSymbol> symbolMock = new();

        ITypeParameterFactory factory = new TypeParameterFactory();

        var sut = factory.Create(symbolMock.Object);

        return new ParameterFixture(sut, symbolMock);
    }

    private sealed class ParameterFixture
        : IParameterFixture
    {
        private readonly ITypeParameter Sut;

        private readonly Mock<ITypeParameterSymbol> SymbolMock;

        public ParameterFixture(
            ITypeParameter sut,
            Mock<ITypeParameterSymbol> symbolMock)
        {
            Sut = sut;

            SymbolMock = symbolMock;
        }

        ITypeParameter IParameterFixture.Sut => Sut;

        Mock<ITypeParameterSymbol> IParameterFixture.SymbolMock => SymbolMock;
    }
}
