namespace Attribinter.Parameters;

using Microsoft.CodeAnalysis;

/// <summary>Represents a type parameter.</summary>
public interface ITypeParameter
{
    /// <summary>The symbol associated with the type parameter.</summary>
    public abstract ITypeParameterSymbol Symbol { get; }
}
