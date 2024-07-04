namespace Paraminter.Parameters;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        GetTypeParameterBySymbolQueryFactory sut = new();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IGetTypeParameterBySymbolQueryFactory Sut;

        public Fixture(
            IGetTypeParameterBySymbolQueryFactory sut)
        {
            Sut = sut;
        }

        IGetTypeParameterBySymbolQueryFactory IFixture.Sut => Sut;
    }
}
