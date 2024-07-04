namespace Paraminter.Parameters;

using Moq;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<ITypeParameterFactory> typeParameterFactoryMock = new();

        GetTypeParameterBySymbolQueryHandler sut = new(typeParameterFactoryMock.Object);

        return new Fixture(sut, typeParameterFactoryMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter> Sut;

        private readonly Mock<ITypeParameterFactory> TypeParameterFactoryMock;

        public Fixture(
            IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter> sut,
            Mock<ITypeParameterFactory> typeParameterFactoryMock)
        {
            Sut = sut;

            TypeParameterFactoryMock = typeParameterFactoryMock;
        }

        IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter> IFixture.Sut => Sut;

        Mock<ITypeParameterFactory> IFixture.TypeParameterFactoryMock => TypeParameterFactoryMock;
    }
}
