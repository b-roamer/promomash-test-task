using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Moq;

namespace Tests.Mocks;

internal class MockUserRepository
{
    public static Mock<IUserRepository> GetMock()
    {
        var mock = new Mock<IUserRepository>();
        IEnumerable<User> users = new List<User>()
        {
            new User
            {
                UserId = Guid.Parse("9FFC59C9-E3B8-4C1B-B59C-AA4F5AB2D5A4"),
                Email = "asd@asd.com",
                CountryId = Guid.NewGuid(),
                ProvinceId = Guid.NewGuid()
            }
        };

        mock.Setup(m => m.GetAll())
            .Returns(() => Task.FromResult(users));

        mock.Setup(m => m.GetById(It.IsAny<Guid>()))
            .Returns((Guid id) => Task.FromResult(users.First(x => x.UserId == id)));

        mock.Setup(m => m.Insert(It.IsAny<Province>()))
            .Callback(() => { });
        
        mock.Setup(m => m.Update(It.IsAny<Province>()))
            .Callback(() => { });
        
        mock.Setup(m => m.Delete(It.IsAny<Guid>()))
            .Callback(() => { });

        
        return mock;
    }
}