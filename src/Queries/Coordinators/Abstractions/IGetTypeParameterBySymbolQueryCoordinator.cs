namespace Paraminter.Parameters.Type.Queries.Coordinators;

using Microsoft.CodeAnalysis;

/// <summary>Coordinates creation and handling of <see cref="IGetTypeParameterBySymbolQuery"/>.</summary>
/// <typeparam name="TResponse">The type representing the response of the query.</typeparam>
public interface IGetTypeParameterBySymbolQueryCoordinator<out TResponse>
{
    /// <summary>Creates and handles a <see cref="IGetTypeParameterBySymbolQuery"/>.</summary>
    /// <param name="symbol">The symbol associated with the type parameter.</param>
    /// <returns>The response of the query.</returns>
    public abstract TResponse Handle(
        ITypeParameterSymbol symbol);
}
