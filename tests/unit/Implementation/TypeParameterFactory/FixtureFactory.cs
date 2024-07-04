namespace Paraminter.Parameters;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        TypeParameterFactory sut = new();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ITypeParameterFactory Sut;

        public Fixture(
            ITypeParameterFactory sut)
        {
            Sut = sut;
        }

        ITypeParameterFactory IFixture.Sut => Sut;
    }
}
