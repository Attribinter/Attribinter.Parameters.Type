namespace Paraminter.Parameters;

using Moq;

internal interface IFixture<TResponse>
{
    public abstract IGetTypeParameterBySymbolQueryCoordinator<TResponse> Sut { get; }

    public abstract Mock<IQueryCoordinator<IGetTypeParameterBySymbolQuery, TResponse, IGetTypeParameterBySymbolQueryFactory>> DelegatingCoordinatorMock { get; }
}
