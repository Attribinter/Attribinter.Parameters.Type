﻿namespace Paraminter.Parameters.GetTypeParameterBySymbolQuery;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IFixture
{
    public abstract IGetTypeParameterBySymbolQuery Sut { get; }

    public abstract Mock<ITypeParameterSymbol> SymbolMock { get; }
}