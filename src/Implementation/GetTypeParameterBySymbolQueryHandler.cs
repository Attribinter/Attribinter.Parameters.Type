namespace Paraminter.Parameters;

using System;

/// <summary>Handles <see cref="IGetTypeParameterBySymbolQuery"/>, and responds with <see cref="ITypeParameter"/>.</summary>
public sealed class GetTypeParameterBySymbolQueryHandler
    : IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter>
{
    private readonly ITypeParameterFactory TypeParameterFactory;

    /// <summary>Instantiates a <see cref="GetTypeParameterBySymbolQueryHandler"/>, handling <see cref="IGetTypeParameterBySymbolQuery"/>.</summary>
    /// <param name="typeParameterFactory">Handles creation of <see cref="ITypeParameter"/>.</param>
    public GetTypeParameterBySymbolQueryHandler(
        ITypeParameterFactory typeParameterFactory)
    {
        TypeParameterFactory = typeParameterFactory ?? throw new ArgumentNullException(nameof(typeParameterFactory));
    }

    ITypeParameter IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter>.Handle(
        IGetTypeParameterBySymbolQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return TypeParameterFactory.Create(query.Symbol);
    }
}
