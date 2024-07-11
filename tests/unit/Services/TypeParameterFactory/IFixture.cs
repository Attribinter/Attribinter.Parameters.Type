namespace Paraminter.Parameters.Type;

using Paraminter.Parameters.Type.Queries;
using Paraminter.Queries.Handlers;

internal interface IFixture
{
    public abstract IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter> Sut { get; }
}
