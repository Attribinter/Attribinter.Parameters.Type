namespace Paraminter.Parameters;

using Microsoft.CodeAnalysis;

/// <summary>Handles creation of <see cref="IGetTypeParameterBySymbolQuery"/>.</summary>
public interface IGetTypeParameterBySymbolQueryFactory
{
    /// <summary>Creates a <see cref="IGetTypeParameterBySymbolQuery"/>.</summary>
    /// <param name="symbol">The symbol associated with the type parameter.</param>
    /// <returns>The created <see cref="IGetTypeParameterBySymbolQuery"/>.</returns>
    public abstract IGetTypeParameterBySymbolQuery Create(
        ITypeParameterSymbol symbol);
}
