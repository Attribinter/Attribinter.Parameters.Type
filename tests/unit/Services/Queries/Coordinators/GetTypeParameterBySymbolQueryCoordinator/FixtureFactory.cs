namespace Paraminter.Parameters.Type.Queries.Coordinators;

using Moq;

using Paraminter.Parameters.Type.Queries.Factories;
using Paraminter.Queries.Coordinators;

internal static class FixtureFactory
{
    public static IFixture<TResponse> Create<TResponse>()
    {
        Mock<IQueryCoordinator<IGetTypeParameterBySymbolQuery, TResponse, IGetTypeParameterBySymbolQueryFactory>> delegatingCoordinatorMock = new();

        GetTypeParameterBySymbolQueryCoordinator<TResponse> sut = new(delegatingCoordinatorMock.Object);

        return new Fixture<TResponse>(sut, delegatingCoordinatorMock);
    }

    private sealed class Fixture<TResponse>
        : IFixture<TResponse>
    {
        private readonly IGetTypeParameterBySymbolQueryCoordinator<TResponse> Sut;

        private readonly Mock<IQueryCoordinator<IGetTypeParameterBySymbolQuery, TResponse, IGetTypeParameterBySymbolQueryFactory>> DelegatingCoordinatorMock;

        public Fixture(
            IGetTypeParameterBySymbolQueryCoordinator<TResponse> sut,
            Mock<IQueryCoordinator<IGetTypeParameterBySymbolQuery, TResponse, IGetTypeParameterBySymbolQueryFactory>> delegatingCoordinatorMock)
        {
            Sut = sut;

            DelegatingCoordinatorMock = delegatingCoordinatorMock;
        }

        IGetTypeParameterBySymbolQueryCoordinator<TResponse> IFixture<TResponse>.Sut => Sut;

        Mock<IQueryCoordinator<IGetTypeParameterBySymbolQuery, TResponse, IGetTypeParameterBySymbolQueryFactory>> IFixture<TResponse>.DelegatingCoordinatorMock => DelegatingCoordinatorMock;
    }
}
