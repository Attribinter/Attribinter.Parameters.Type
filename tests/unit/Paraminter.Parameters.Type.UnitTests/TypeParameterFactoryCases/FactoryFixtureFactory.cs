namespace Paraminter.Parameters.TypeParameterFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        TypeParameterFactory sut = new();

        return new FactoryFixture(sut);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly ITypeParameterFactory Sut;

        public FactoryFixture(ITypeParameterFactory sut)
        {
            Sut = sut;
        }

        ITypeParameterFactory IFactoryFixture.Sut => Sut;
    }
}
