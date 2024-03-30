namespace Attribinter.Parameters;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="ITypeParameter"/>.</summary>
public interface ITypeParameterFactory
{
    /// <summary>Creates a <see cref="ITypeParameter"/>, representing a type parameter.</summary>
    /// <param name="symbol">The symbol associated with the type parameter.</param>
    /// <returns>The created <see cref="ITypeParameter"/>.</returns>
    public abstract ITypeParameter Create(ITypeParameterSymbol symbol);
}
