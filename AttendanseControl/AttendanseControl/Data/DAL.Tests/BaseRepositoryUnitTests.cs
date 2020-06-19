using System.Collections.Generic;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Impl;
using DAL.Entities;
using DAL.EF;

namespace DAL.Tests
{
    class TestPresenceRepository
        : BaseRepository<Presence>
    {
        public TestPresenceRepository(DbContext context)
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputStreetInstance_CalledAddMethodOfDBSetWithStreetInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<AttendanseControlContext>()
                .Options;
            var mockContext = new Mock<AttendanseControlContext>(opt);
            var mockDbSet = new Mock<DbSet<Presence>>();
            mockContext
                .Setup(context =>
                    context.Set<Presence>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestPresenceRepository(mockContext.Object);

            Presence expectedStreet = new Mock<Presence>().Object;

            //Act
            repository.Create(expectedStreet);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedStreet
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<AttendanseControlContext>()
                .Options;
            var mockContext = new Mock<AttendanseControlContext>(opt);
            var mockDbSet = new Mock<DbSet<Presence>>();
            mockContext
                .Setup(context =>
                    context.Set<Presence>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IStreetRepository repository = uow.Streets;
            var repository = new TestPresenceRepository(mockContext.Object);

            Presence expectedStreet = new Presence() { PresenceID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.PresenceID)).Returns(expectedStreet);

            //Act
            repository.Delete(expectedStreet.PresenceID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.PresenceID
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedStreet
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<AttendanseControlContext>()
                .Options;
            var mockContext = new Mock<AttendanseControlContext>(opt);
            var mockDbSet = new Mock<DbSet<Presence>>();
            mockContext
                .Setup(context =>
                    context.Set<Presence>(
                        ))
                .Returns(mockDbSet.Object);

            Presence expectedStreet = new Presence() { PresenceID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.PresenceID))
                    .Returns(expectedStreet);
            var repository = new TestPresenceRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedStreet.PresenceID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedStreet.PresenceID
                    ), Times.Once());
            Assert.Equal(expectedStreet, actualStreet);
        }


    }
}
