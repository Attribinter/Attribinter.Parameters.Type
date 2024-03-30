namespace Attribinter.Parameters;

using Microsoft.Extensions.DependencyInjection;

using System;

/// <summary>Allows the services of <i>Attribinter.Parameters.Type</i> to be registered with <see cref="IServiceCollection"/>.</summary>
public static class AttribinterTypeParametersServices
{
    /// <summary>Registers the services of <i>Attribinter.Parameters.Type</i> with the provided <see cref="IServiceCollection"/>.</summary>
    /// <param name="services">The <see cref="IServiceCollection"/> with which services are registered.</param>
    /// <returns>The provided <see cref="IServiceCollection"/>, so that calls can be chained.</returns>
    public static IServiceCollection AddAttribinterTypeParameters(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddTransient<ITypeParameterFactory, TypeParameterFactory>();

        return services;
    }
}
