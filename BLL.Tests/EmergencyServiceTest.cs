using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Tests
{
    public class EmergencyServiceTest
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new EmergencyService(nullUnitOfWork));
        }

        [Fact]
        public void GetEmergency_FromDAL_CorrectMappingToDTO()
        {
            var emergencyService = GetEmergencyService();

            var actual = emergencyService.GetEmergencies(1,0).First();

            Assert.True(
                actual.StreetId == 1
                && actual.Id == 2
                && actual.House == 2
                && actual.TypeId == 1
                );
        }

        IEmergencyService GetEmergencyService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedEmergency = new Emergency() { Id = 2, Date = new DateOnly(), StreetId = 1, House = 2, TypeId = 1};
            var mockDbSet = new Mock<IEmergencyRepository>();
            mockDbSet.Setup(e =>e.Find(It.IsAny<Func<Emergency, bool>>(),It.IsAny<int>(), It.IsAny<int>()))
                .Returns(
                    new List<Emergency>() { expectedEmergency }
                    );
            mockContext.Setup(context => context.Emergencies).Returns(mockDbSet.Object);

            IEmergencyService emergencyService = new EmergencyService(mockContext.Object);

            return emergencyService;
        }
    }
}
