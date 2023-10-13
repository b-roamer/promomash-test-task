using System;
using System.Collections.Generic;
using System.Threading;
using Application.Countries.Queries;
using Application.Countries.QueryHandlers;
using Domain.Entities;
using Tests.Mocks;
using Xunit;

namespace Tests.Tests;

public class CountriesTests
{
    [Fact]
    public async void WhenGettingAllCountries_ThenAllCountriesReturn()
    {
        var mockCountriesRepository = MockCountriesRepository.GetMock();
        
        var query = new GetAllCountries();
        var handler = new GetAllCountriesHandler(mockCountriesRepository.Object);

        var result = await handler.Handle(query, new CancellationToken());

        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Country>>(result);
    }
    
    [Fact]
    public async void WhenGettingCountryById_ThenCountryWithMatchingIdReturns()
    {
        var mockCountriesRepository = MockCountriesRepository.GetMock();
        
        var query = new GetCountryById(Guid.Parse("2EB8FB8B-7C66-4413-B18F-F25E91CA0809"));
        var handler = new GetCountryByIdHandler(mockCountriesRepository.Object);

        var result = await handler.Handle(query, new CancellationToken());

        Assert.NotNull(result);
        Assert.IsAssignableFrom<Country>(result);
        Assert.Equal(Guid.Parse("2EB8FB8B-7C66-4413-B18F-F25E91CA0809"), result.CountryId);
    }
}