namespace Paraminter.Parameters;

using Microsoft.CodeAnalysis;

/// <summary>Represents a query for a type parameter, given the symbol associated with the type parameter.</summary>
public interface IGetTypeParameterBySymbolQuery
    : IQuery
{
    /// <summary>The symbol associated with the type parameter.</summary>
    public abstract ITypeParameterSymbol Symbol { get; }
}
