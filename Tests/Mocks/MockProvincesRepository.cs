using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Domain.Entities;
using Moq;

namespace Tests.Mocks;

internal class MockProvincesRepository
{
    public static Mock<IProvinceRepository> GetMock()
    {
        var mock = new Mock<IProvinceRepository>();
        var provinces = SeedData.Provinces;

        mock.Setup(m => m.GetAll())
            .Returns(() => Task.FromResult(provinces));

        mock.Setup(m => m.GetById(It.IsAny<Guid>()))
            .Returns((Guid id) => Task.FromResult(provinces.First(x => x.ProvinceId == id)));

        mock.Setup(m => m.Insert(It.IsAny<Province>()))
            .Callback(() => { });
        
        mock.Setup(m => m.Update(It.IsAny<Province>()))
            .Callback(() => { });
        
        mock.Setup(m => m.Delete(It.IsAny<Guid>()))
            .Callback(() => { });
        
        return mock;
    }
}