namespace Paraminter.Parameters;

internal interface IFixture
{
    public abstract IQueryHandler<IGetTypeParameterQuery, ITypeParameter> Sut { get; }
}
