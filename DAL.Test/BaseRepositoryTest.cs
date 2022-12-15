using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DAL.Test
{
    class TestEmergencyRepository
        : BaseRepository<Emergency>
    {
        public TestEmergencyRepository(DbContext context)
            : base(context)
        {
        }
    }

    public class BaseRepositoryTest
    {
        [Fact]
        public void Create_Emergencye_CallAddMethodOfDBSetWithEmergency()
        {
            var options = new DbContextOptionsBuilder<EmergencyContext>().Options;
            var mockContext = new Mock<EmergencyContext>(options);
            var mockDbSet = new Mock<DbSet<Emergency>>();
            mockContext.Setup(context => context.Set<Emergency>()).Returns(mockDbSet.Object);

            var repository = new TestEmergencyRepository(mockContext.Object);

            Emergency expected = new Mock<Emergency>().Object;

            repository.Create(expected);

            mockDbSet.Verify(dbSet => dbSet.Add(expected), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            var options = new DbContextOptionsBuilder<EmergencyContext>().Options;
            var mockContext = new Mock<EmergencyContext>(options);
            var mockDbSet = new Mock<DbSet<Emergency>>();
            mockContext.Setup(context => context.Set<Emergency>()).Returns(mockDbSet.Object);
       
            var repository = new TestEmergencyRepository(mockContext.Object);

            Emergency expected = new Emergency() { Id = 1, StreetId = 2, House = 3, TypeId = 1 };
            mockDbSet.Setup(mock => mock.Find(expected.Id)).Returns(expected);

            repository.Delete(expected.Id);

            mockDbSet.Verify(dbSet => dbSet.Find(expected.Id), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expected), Times.Once());
        }


        [Fact]
        public void Get_Emergency_CalledFindMethodOfDBSetWithCorrectId()
        {
            var options = new DbContextOptionsBuilder<EmergencyContext>().Options;
            var mockContext = new Mock<EmergencyContext>(options);
            var mockDbSet = new Mock<DbSet<Emergency>>();
            mockContext.Setup(context => context.Set<Emergency>()).Returns(mockDbSet.Object);

            Emergency expected = new Emergency() { Id = 1, StreetId=2, House=3, TypeId=1 };
            mockDbSet.Setup(mock => mock.Find(expected.Id)).Returns(expected);
            var repository = new TestEmergencyRepository(mockContext.Object);

            Emergency actual = repository.Get(expected.Id);

            mockDbSet.Verify(dbSet => dbSet.Find( expected.Id), Times.Once());
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_Emergency_CalledFindMethodOfDBSetWithNotCorrectId()
        {
            var options = new DbContextOptionsBuilder<EmergencyContext>().Options;
            var mockContext = new Mock<EmergencyContext>(options);
            var mockDbSet = new Mock<DbSet<Emergency>>();
            mockContext.Setup(context => context.Set<Emergency>()).Returns(mockDbSet.Object);

            Emergency expected = new Emergency() { Id = 1, StreetId = 2, House = 3, TypeId = 1 };
            mockDbSet.Setup(mock => mock.Find(expected.Id)).Returns(expected);
            var repository = new TestEmergencyRepository(mockContext.Object);

            Emergency actual = repository.Get(2);

            mockDbSet.Verify(dbSet => dbSet.Find(2), Times.Once());
            Assert.NotEqual(expected, actual);
        }

    }
}
