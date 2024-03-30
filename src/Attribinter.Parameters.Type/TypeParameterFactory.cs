namespace Attribinter.Parameters;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="ITypeParameterFactory"/>
public sealed class TypeParameterFactory : ITypeParameterFactory
{
    /// <summary>Instantiates a <see cref="TypeParameterFactory"/>, handling creation of <see cref="ITypeParameter"/>.</summary>
    public TypeParameterFactory() { }

    ITypeParameter ITypeParameterFactory.Create(ITypeParameterSymbol symbol)
    {
        if (symbol is null)
        {
            throw new ArgumentNullException(nameof(symbol));
        }

        return new TypeParameter(symbol);
    }

    private sealed class TypeParameter : ITypeParameter
    {
        private readonly ITypeParameterSymbol Symbol;

        public TypeParameter(ITypeParameterSymbol symbol)
        {
            Symbol = symbol;
        }

        ITypeParameterSymbol ITypeParameter.Symbol => Symbol;
    }
}
