namespace Paraminter.Parameters;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class Handle
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullQuery_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidQuery_ReturnsTypeParameter()
    {
        var symbol = Mock.Of<ITypeParameterSymbol>();
        var typeParameter = Mock.Of<ITypeParameter>();

        Mock<IGetTypeParameterBySymbolQuery> queryMock = new();

        queryMock.Setup(static (query) => query.Symbol).Returns(symbol);

        Fixture.TypeParameterFactoryMock.Setup((factory) => factory.Create(symbol)).Returns(typeParameter);

        var result = Target(queryMock.Object);

        Assert.Same(typeParameter, result);
    }

    private ITypeParameter Target(
        IGetTypeParameterBySymbolQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
