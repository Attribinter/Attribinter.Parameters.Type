namespace Paraminter.Parameters.TypeParameter;

using Microsoft.CodeAnalysis;

using Moq;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<ITypeParameterSymbol> symbolMock = new();

        Mock<IGetTypeParameterQuery> queryMock = new();

        queryMock.Setup(static (query) => query.Symbol).Returns(symbolMock.Object);

        IQueryHandler<IGetTypeParameterQuery, ITypeParameter> factory = new GetTypeParameterQueryHandler();

        var sut = factory.Handle(queryMock.Object);

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
