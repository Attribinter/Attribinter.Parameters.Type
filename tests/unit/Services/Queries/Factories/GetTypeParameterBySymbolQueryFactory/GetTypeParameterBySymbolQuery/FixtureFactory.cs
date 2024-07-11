namespace Paraminter.Parameters.Type.Queries.Factories.GetTypeParameterBySymbolQuery;

using Microsoft.CodeAnalysis;

using Moq;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<ITypeParameterSymbol> symbolMock = new();

        IGetTypeParameterBySymbolQueryFactory factory = new GetTypeParameterBySymbolQueryFactory();

        var sut = factory.Create(symbolMock.Object);

        return new Fixture(sut, symbolMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IGetTypeParameterBySymbolQuery Sut;

        private readonly Mock<ITypeParameterSymbol> SymbolMock;

        public Fixture(
            IGetTypeParameterBySymbolQuery sut,
            Mock<ITypeParameterSymbol> symbolMock)
        {
            Sut = sut;

            SymbolMock = symbolMock;
        }

        IGetTypeParameterBySymbolQuery IFixture.Sut => Sut;

        Mock<ITypeParameterSymbol> IFixture.SymbolMock => SymbolMock;
    }
}
