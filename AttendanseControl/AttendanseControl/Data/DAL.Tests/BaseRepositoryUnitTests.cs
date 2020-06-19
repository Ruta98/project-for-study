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
        public void Create_InputUserInstance_CalledAddMethodOfDBSetWithUserInstance()
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

            Presence expectedUser = new Mock<Presence>().Object;

            //Act
            repository.Create(expectedUser);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedUser
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
            //IUserRepository repository = uow.Users;
            var repository = new TestPresenceRepository(mockContext.Object);

            Presence expectedUser = new Presence() { PresenceID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedUser.PresenceID)).Returns(expectedUser);

            //Act
            repository.Delete(expectedUser.PresenceID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedUser.PresenceID
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedUser
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

            Presence expectedUser = new Presence() { PresenceID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedUser.PresenceID))
                    .Returns(expectedUser);
            var repository = new TestPresenceRepository(mockContext.Object);

            //Act
            var actualUser = repository.Get(expectedUser.PresenceID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedUser.PresenceID
                    ), Times.Once());
            Assert.Equal(expectedUser, actualUser);
        }


    }
}
