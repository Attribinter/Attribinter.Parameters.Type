namespace Paraminter.Parameters;

internal interface IFixture
{
    public abstract IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter> Sut { get; }
}
