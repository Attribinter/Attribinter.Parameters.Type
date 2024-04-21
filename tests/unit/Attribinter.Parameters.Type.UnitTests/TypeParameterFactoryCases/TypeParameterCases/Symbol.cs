﻿namespace Attribinter.Parameters.TypeParameterFactoryCases.TypeParameterCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class Symbol
{
    private ITypeParameterSymbol Target() => Fixture.Sut.Symbol;

    private readonly IParameterFixture Fixture = ParameterFixtureFactory.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.SymbolMock.Object, result);
    }
}
