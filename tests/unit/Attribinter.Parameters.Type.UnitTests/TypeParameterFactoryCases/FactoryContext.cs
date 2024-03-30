namespace Attribinter.Parameters.TypeParameterFactoryCases;

internal sealed class FactoryContext
{
    public static FactoryContext Create()
    {
        ITypeParameterFactory factory = new TypeParameterFactory();

        return new(factory);
    }

    public ITypeParameterFactory Factory { get; }

    private FactoryContext(ITypeParameterFactory factory)
    {
        Factory = factory;
    }
}
