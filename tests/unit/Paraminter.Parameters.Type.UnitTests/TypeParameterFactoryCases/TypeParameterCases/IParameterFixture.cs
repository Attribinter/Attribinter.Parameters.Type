namespace Paraminter.Parameters.TypeParameterFactoryCases.TypeParameterCases;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IParameterFixture
{
    public abstract ITypeParameter Sut { get; }

    public abstract Mock<ITypeParameterSymbol> SymbolMock { get; }
}
