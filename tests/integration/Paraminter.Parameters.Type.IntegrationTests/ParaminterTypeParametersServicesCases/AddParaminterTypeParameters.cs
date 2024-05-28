namespace Paraminter.Parameters.ParaminterParametersServicesCases;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Xunit;

public sealed class AddParaminterTypeParameters
{
    [Fact]
    public void ITypeParameterFactory_ServiceCanBeResolved() => ServiceCanBeResolved<ITypeParameterFactory>();

    private static void Target(
        IServiceCollection services)
    {
        ParaminterTypeParametersServices.AddParaminterTypeParameters(services);
    }

    [AssertionMethod]
    private static void ServiceCanBeResolved<TService>()
        where TService : notnull
    {
        HostBuilder host = new();

        host.ConfigureServices(static (services) => Target(services));

        var serviceProvider = host.Build().Services;

        var result = serviceProvider.GetRequiredService<TService>();

        Assert.NotNull(result);
    }
}
