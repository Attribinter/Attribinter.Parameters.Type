namespace Paraminter.Parameters;

using Microsoft.CodeAnalysis;

using Moq;

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
    public void ValidArguments_HandlesCommand()
    {
        var fixture = FixtureFactory.Create<object>();

        var symbol = Mock.Of<ITypeParameterSymbol>();

        Target(fixture, symbol);

        fixture.DelegatingCoordinatorMock.Verify((coordinator) => coordinator.Handle(It.Is(MatchCommandCreationDelegate(symbol))), Times.Once);
    }

    private static Expression<Func<DCreateQuery<IGetTypeParameterBySymbolQuery, IGetTypeParameterBySymbolQueryFactory>, bool>> MatchCommandCreationDelegate(
        ITypeParameterSymbol symbol)
    {
        return (commandCreationDelegate) => VerifyCommandCreationDelegate(commandCreationDelegate, symbol);
    }

    private static bool VerifyCommandCreationDelegate(
        DCreateQuery<IGetTypeParameterBySymbolQuery, IGetTypeParameterBySymbolQueryFactory> queryCreationDelegate,
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
