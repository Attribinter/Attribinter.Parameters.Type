namespace Paraminter.Parameters.Type.Models;

using Microsoft.CodeAnalysis;

using Paraminter.Parameters.Models;

/// <summary>Represents a type parameter.</summary>
public interface ITypeParameter
    : IParameter
{
    /// <summary>The symbol associated with the type parameter.</summary>
    public abstract ITypeParameterSymbol Symbol { get; }
}
