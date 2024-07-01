namespace Paraminter.Parameters;

using Microsoft.CodeAnalysis;

using System;

/// <summary>Handles <see cref="IGetTypeParameterBySymbolQuery"/>, and responds with <see cref="ITypeParameter"/>.</summary>
public sealed class GetTypeParameterBySymbolQueryHandler
    : IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter>
{
    /// <summary>Instantiates a <see cref="GetTypeParameterBySymbolQueryHandler"/>, handling <see cref="IGetTypeParameterBySymbolQuery"/>.</summary>
    public GetTypeParameterBySymbolQueryHandler() { }

    ITypeParameter IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter>.Handle(
        IGetTypeParameterBySymbolQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return new TypeParameter(query.Symbol);
    }

    private sealed class TypeParameter
        : ITypeParameter
    {
        private readonly ITypeParameterSymbol Symbol;

        public TypeParameter(
            ITypeParameterSymbol symbol)
        {
            Symbol = symbol;
        }

        ITypeParameterSymbol ITypeParameter.Symbol => Symbol;
    }
}
