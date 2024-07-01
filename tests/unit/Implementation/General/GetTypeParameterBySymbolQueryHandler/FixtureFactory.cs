namespace Paraminter.Parameters;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        GetTypeParameterBySymbolQueryHandler sut = new();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter> Sut;

        public Fixture(
            IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter> sut)
        {
            Sut = sut;
        }

        IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter> IFixture.Sut => Sut;
    }
}
