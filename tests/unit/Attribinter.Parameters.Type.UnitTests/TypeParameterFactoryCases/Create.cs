namespace Attribinter.Parameters.TypeParameterFactoryCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;

using Xunit;

public sealed class Create
{
    private static ITypeParameter Target(ITypeParameterSymbol symbol) => Context.Factory.Create(symbol);

    private static readonly FactoryContext Context = FactoryContext.Create();

    [Fact]
    public void NullSymbol_ThrowsArgumentNullException()
    {
        var exception = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void ValidSymbol_ContainsSymbol()
    {
        var symbol = Mock.Of<ITypeParameterSymbol>();

        var result = Target(symbol);

        Assert.Same(symbol, result.Symbol);
    }
}
