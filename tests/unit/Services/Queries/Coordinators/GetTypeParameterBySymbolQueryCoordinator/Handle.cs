namespace Paraminter.Parameters;

using Microsoft.CodeAnalysis;

using Moq;

using Paraminter.Parameters.Type.Queries;
using Paraminter.Parameters.Type.Queries.Coordinators;
using Paraminter.Parameters.Type.Queries.Factories;
using Paraminter.Queries.Coordinators;

using System;
using System.Linq.Expressions;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullSymbol_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<object>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_HandlesQuery()
    {
        var fixture = FixtureFactory.Create<object>();

        var symbol = Mock.Of<ITypeParameterSymbol>();

        var response = Mock.Of<object>();

        fixture.DelegatingCoordinatorMock.Setup(CoordinatorExpression<object>(symbol)).Returns(response);

        var result = Target(fixture, symbol);

        Assert.Same(response, result);

        fixture.DelegatingCoordinatorMock.Verify(CoordinatorExpression<object>(symbol), Times.Once);
    }

    private static Expression<Func<IQueryCoordinator<IGetTypeParameterBySymbolQuery, TResponse, IGetTypeParameterBySymbolQueryFactory>, TResponse>> CoordinatorExpression<TResponse>(
        ITypeParameterSymbol symbol)
    {
        return (coordinator) => coordinator.Handle(It.Is(MatchQueryCreationDelegate(symbol)));
    }

    private static Expression<Func<DCreateQueryThroughFactory<IGetTypeParameterBySymbolQueryFactory, IGetTypeParameterBySymbolQuery>, bool>> MatchQueryCreationDelegate(
        ITypeParameterSymbol symbol)
    {
        return (queryCreationDelegate) => VerifyQueryCreationDelegate(queryCreationDelegate, symbol);
    }

    private static bool VerifyQueryCreationDelegate(
        DCreateQueryThroughFactory<IGetTypeParameterBySymbolQueryFactory, IGetTypeParameterBySymbolQuery> queryCreationDelegate,
        ITypeParameterSymbol symbol)
    {
        var query = Mock.Of<IGetTypeParameterBySymbolQuery>();

        Mock<IGetTypeParameterBySymbolQueryFactory> queryFactoryMock = new();

        queryFactoryMock.Setup((factory) => factory.Create(symbol)).Returns(query);

        var result = queryCreationDelegate(queryFactoryMock.Object);

        return ReferenceEquals(result, query);
    }

    private static TResponse Target<TResponse>(
        IFixture<TResponse> fixture,
        ITypeParameterSymbol symbol)
    {
        return fixture.Sut.Handle(symbol);
    }
}
