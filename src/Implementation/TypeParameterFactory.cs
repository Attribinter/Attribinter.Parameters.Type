namespace Paraminter.Parameters;

using Microsoft.CodeAnalysis;

using System;

/// <summary>Handles creation of <see cref="ITypeParameter"/>.</summary>
public sealed class TypeParameterFactory
    : IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter>
{
    /// <summary>Instantiates a <see cref="TypeParameterFactory"/>, handling creation of <see cref="ITypeParameter"/>.</summary>
    public TypeParameterFactory() { }

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
