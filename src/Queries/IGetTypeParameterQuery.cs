namespace Paraminter.Parameters;

using Microsoft.CodeAnalysis;

using Paraminter.Queries;

/// <summary>Represents a query for a type parameter.</summary>
public interface IGetTypeParameterQuery
    : IQuery
{
    /// <summary>The symbol associated with the type parameter.</summary>
    public abstract ITypeParameterSymbol Symbol { get; }
}
