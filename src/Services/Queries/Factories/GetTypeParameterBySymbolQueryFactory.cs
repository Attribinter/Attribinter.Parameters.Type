namespace Paraminter.Parameters.Type.Queries.Factories;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="IGetTypeParameterBySymbolQueryFactory"/>
public sealed class GetTypeParameterBySymbolQueryFactory
    : IGetTypeParameterBySymbolQueryFactory
{
    /// <summary>Instantiates a <see cref="GetTypeParameterBySymbolQueryFactory"/>, handling creation of <see cref="IGetTypeParameterBySymbolQuery"/>.</summary>
    public GetTypeParameterBySymbolQueryFactory() { }

    IGetTypeParameterBySymbolQuery IGetTypeParameterBySymbolQueryFactory.Create(
        ITypeParameterSymbol symbol)
    {
        if (symbol is null)
        {
            throw new ArgumentNullException(nameof(symbol));
        }

        return new GetTypeParameterBySymbolQuery(symbol);
    }

    private sealed class GetTypeParameterBySymbolQuery
        : IGetTypeParameterBySymbolQuery
    {
        private readonly ITypeParameterSymbol Symbol;

        public GetTypeParameterBySymbolQuery(
            ITypeParameterSymbol symbol)
        {
            Symbol = symbol;
        }

        ITypeParameterSymbol IGetTypeParameterBySymbolQuery.Symbol => Symbol;
    }
}
