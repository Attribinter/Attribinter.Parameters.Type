namespace Paraminter.Parameters.TypeParameter;

using Moq;

using Paraminter.Queries;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IGetTypeParameterQuery> queryMock = new() { DefaultValue = DefaultValue.Mock };

        IQueryHandler<IGetTypeParameterQuery, ITypeParameter> factory = new GetTypeParameterQueryHandler();

        var sut = factory.Handle(queryMock.Object);

        return new Fixture(sut, queryMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ITypeParameter Sut;

        private readonly Mock<IGetTypeParameterQuery> QueryMock;

        public Fixture(
            ITypeParameter sut,
            Mock<IGetTypeParameterQuery> queryMock)
        {
            Sut = sut;

            QueryMock = queryMock;
        }

        ITypeParameter IFixture.Sut => Sut;

        Mock<IGetTypeParameterQuery> IFixture.QueryMock => QueryMock;
    }
}
