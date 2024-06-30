namespace Paraminter.Parameters;

using Microsoft.CodeAnalysis;

using System;

/// <summary>Handles <see cref="IGetTypeParameterQuery"/>, and responds with <see cref="ITypeParameter"/>.</summary>
public sealed class GetTypeParameterQueryHandler
    : IQueryHandler<IGetTypeParameterQuery, ITypeParameter>
{
    /// <summary>Instantiates a <see cref="GetTypeParameterQueryHandler"/>, handling <see cref="IGetTypeParameterQuery"/>.</summary>
    public GetTypeParameterQueryHandler() { }

    ITypeParameter IQueryHandler<IGetTypeParameterQuery, ITypeParameter>.Handle(
        IGetTypeParameterQuery query)
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
