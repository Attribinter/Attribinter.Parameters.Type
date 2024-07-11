namespace Paraminter.Parameters.Type.Queries.Coordinators;

using Moq;

using Paraminter.Parameters.Type.Queries.Factories;
using Paraminter.Queries.Coordinators;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullDelegatingCoordinator_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsCoordinator()
    {
        var result = Target(Mock.Of<IQueryCoordinator<IGetTypeParameterBySymbolQuery, object, IGetTypeParameterBySymbolQueryFactory>>());

        Assert.NotNull(result);
    }

    private static GetTypeParameterBySymbolQueryCoordinator<TResponse> Target<TResponse>(
        IQueryCoordinator<IGetTypeParameterBySymbolQuery, TResponse, IGetTypeParameterBySymbolQueryFactory> delegatingCoordinator)
    {
        return new GetTypeParameterBySymbolQueryCoordinator<TResponse>(delegatingCoordinator);
    }
}
