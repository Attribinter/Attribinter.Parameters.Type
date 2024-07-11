namespace Paraminter.Parameters.Type.Queries.Coordinators;

using Moq;

using Paraminter.Parameters.Type.Queries.Factories;
using Paraminter.Queries.Coordinators;

internal interface IFixture<TResponse>
{
    public abstract IGetTypeParameterBySymbolQueryCoordinator<TResponse> Sut { get; }

    public abstract Mock<IQueryCoordinator<IGetTypeParameterBySymbolQuery, TResponse, IGetTypeParameterBySymbolQueryFactory>> DelegatingCoordinatorMock { get; }
}
