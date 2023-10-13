using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Domain.Entities;
using Moq;

namespace Tests.Mocks;

internal class MockCountriesRepository
{
    public static Mock<ICountryRepository> GetMock()
    {
        var mock = new Mock<ICountryRepository>();
        var countries = SeedData.Countries;

        mock.Setup(m => m.GetAll())
            .Returns(() => Task.FromResult(countries));

        mock.Setup(m => m.GetById(It.IsAny<Guid>()))
            .Returns((Guid id) => Task.FromResult(countries.First(x => x.CountryId == id)));

        mock.Setup(m => m.Insert(It.IsAny<Country>()))
            .Callback(() => { });
        
        mock.Setup(m => m.Update(It.IsAny<Country>()))
            .Callback(() => { });
        
        mock.Setup(m => m.Delete(It.IsAny<Guid>()))
            .Callback(() => { });
        
        return mock;
    }
}