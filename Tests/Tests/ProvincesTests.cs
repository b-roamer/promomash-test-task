using System;
using System.Collections.Generic;
using System.Threading;
using Application.Provinces.Queries;
using Application.Provinces.QueryHandlers;
using Domain.Entities;
using Tests.Mocks;
using Xunit;

namespace Tests.Tests;

public class ProvincesTests
{
    [Fact]
    public async void WhenGettingAllProvinces_ThenAllProvincesReturn()
    {
        var mockProvincesRepository = MockProvincesRepository.GetMock();
        
        var query = new GetAllProvinces();
        var handler = new GetAllProvincesHandler(mockProvincesRepository.Object);

        var result = await handler.Handle(query, new CancellationToken());

        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Province>>(result);
    }
    
    [Fact]
    public async void WhenGettingProvinceById_ThenProvinceWithMatchingIdReturns()
    {
        var mockProvincesRepository = MockProvincesRepository.GetMock();
        
        var query = new GetProvinceById(Guid.Parse("0E277EBA-E766-4BD4-996F-EC4624603F47"));
        var handler = new GetProvinceByIdHandler(mockProvincesRepository.Object);

        var result = await handler.Handle(query, new CancellationToken());

        Assert.NotNull(result);
        Assert.IsAssignableFrom<Province>(result);
        Assert.Equal(Guid.Parse("0E277EBA-E766-4BD4-996F-EC4624603F47"), result.ProvinceId);
    }
}