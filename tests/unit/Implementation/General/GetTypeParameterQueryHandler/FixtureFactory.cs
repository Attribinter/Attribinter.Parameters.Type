namespace Paraminter.Parameters;

using Paraminter.Queries;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        GetTypeParameterQueryHandler sut = new();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IQueryHandler<IGetTypeParameterQuery, ITypeParameter> Sut;

        public Fixture(
            IQueryHandler<IGetTypeParameterQuery, ITypeParameter> sut)
        {
            Sut = sut;
        }

        IQueryHandler<IGetTypeParameterQuery, ITypeParameter> IFixture.Sut => Sut;
    }
}
