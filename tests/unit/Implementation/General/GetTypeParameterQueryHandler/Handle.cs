namespace Paraminter.Parameters;

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
        var result = Target(Mock.Of<IGetTypeParameterQuery>());

        Assert.NotNull(result);
    }

    private ITypeParameter Target(
        IGetTypeParameterQuery query)
    {
        return Fixture.Sut.Handle(query);
    }
}
