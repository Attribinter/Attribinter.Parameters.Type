namespace Paraminter.Parameters;

using Moq;

internal interface IFixture
{
    public abstract IQueryHandler<IGetTypeParameterBySymbolQuery, ITypeParameter> Sut { get; }

    public abstract Mock<ITypeParameterFactory> TypeParameterFactoryMock { get; }
}
