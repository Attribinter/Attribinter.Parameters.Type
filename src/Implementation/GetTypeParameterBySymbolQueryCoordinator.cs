namespace Paraminter.Parameters;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="IGetTypeParameterBySymbolQueryCoordinator{TResponse}"/>
public sealed class GetTypeParameterBySymbolQueryCoordinator<TResponse>
    : IGetTypeParameterBySymbolQueryCoordinator<TResponse>
{
    private readonly IQueryCoordinator<IGetTypeParameterBySymbolQuery, TResponse, IGetTypeParameterBySymbolQueryFactory> DelegatingCoordinator;

    /// <summary>Instantiates a <see cref="GetTypeParameterBySymbolQueryCoordinator{TResponse}"/>, coordinating creation of handling of <see cref="IGetTypeParameterBySymbolQuery"/>.</summary>
    /// <param name="delegatingCoordinator">Coordinates creation and handling of queries.</param>
    public GetTypeParameterBySymbolQueryCoordinator(
        IQueryCoordinator<IGetTypeParameterBySymbolQuery, TResponse, IGetTypeParameterBySymbolQueryFactory> delegatingCoordinator)
    {
        DelegatingCoordinator = delegatingCoordinator ?? throw new ArgumentNullException(nameof(delegatingCoordinator));
    }

    TResponse IGetTypeParameterBySymbolQueryCoordinator<TResponse>.Handle(
        ITypeParameterSymbol symbol)
    {
        if (symbol is null)
        {
            throw new ArgumentNullException(nameof(symbol));
        }

        return DelegatingCoordinator.Handle(createQuery);

        IGetTypeParameterBySymbolQuery createQuery(
            IGetTypeParameterBySymbolQueryFactory factory)
        {
            return factory.Create(symbol);
        }
    }
}
