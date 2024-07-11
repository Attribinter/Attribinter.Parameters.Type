namespace Paraminter.Parameters.Type;

using Moq;

using Paraminter.Parameters.Type.Queries;

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
    public void ValidQuery_ReturnsParameter()
    {
        var result = Target(Mock.Of<IGetTypeParameterBySymbolQuery>());

        Assert.NotNull(result);
    }

    private ITypeParameter Target(
        IGetTypeParameterBySymbolQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
