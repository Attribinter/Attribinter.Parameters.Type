namespace Paraminter.Parameters.TypeParameter;

using Moq;

internal interface IFixture
{
    public abstract ITypeParameter Sut { get; }

    public abstract Mock<IGetTypeParameterQuery> QueryMock { get; }
}
