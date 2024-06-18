namespace Paraminter.Parameters.TypeParameter;

using Microsoft.CodeAnalysis;

using Moq;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<ITypeParameterSymbol> symbolMock = new();

        ITypeParameterFactory factory = new TypeParameterFactory();

        var sut = factory.Create(symbolMock.Object);

        return new Fixture(sut, symbolMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ITypeParameter Sut;

        private readonly Mock<ITypeParameterSymbol> SymbolMock;

        public Fixture(
            ITypeParameter sut,
            Mock<ITypeParameterSymbol> symbolMock)
        {
            Sut = sut;

            SymbolMock = symbolMock;
        }

        ITypeParameter IFixture.Sut => Sut;

        Mock<ITypeParameterSymbol> IFixture.SymbolMock => SymbolMock;
    }
}
