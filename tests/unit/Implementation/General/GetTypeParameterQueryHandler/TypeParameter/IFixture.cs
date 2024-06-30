namespace Paraminter.Parameters.TypeParameter;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IFixture
{
    public abstract ITypeParameter Sut { get; }

    public abstract Mock<ITypeParameterSymbol> SymbolMock { get; }
}
