namespace Paraminter.Parameters;

using Paraminter.Queries;

internal interface IFixture
{
    public abstract IQueryHandler<IGetTypeParameterQuery, ITypeParameter> Sut { get; }
}
