using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CLL.Identity;
using CLL.Security;
using DAL.UnitOfWork;
using Moq;
using System;
using Xunit;

namespace BLL.Tests
{
    [Fact]
    public void Ctor_InputNull_ThrowArgumentNullException()
    {
        // Arrange
        IUnitOfWork nullUnitOfWork = null;

        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(() => new HistoryService(nullUnitOfWork));
    }

    [Fact]
    public void GetUsers_UserIsAdmin_ThrowMethodAccessException()
    {
        // Arrange
        User user = new Admin(1, "test", "test");
        SecurityContext.SetUser(user);
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        IHistoryService UserService = new HistoryService(mockUnitOfWork.Object);

        // Act
        // Assert
        Assert.Throws<MethodAccessException>(() => HistoryService.GetUsers(0));
    }

    [Fact]
    public void GetUsers_UserFromDAL_CorrectMappingToUserDTO()
    {
        // Arrange
        User user = new Admin(1, "test", "test");
        SecurityContext.SetUser(user);
        var HistoryService = GetHistoryService();

        // Act
        var actualUserDto = HistoryService.GetUsers(0).First();

        // Assert
        Assert.True(
            actualUserDto.UserId == 1
            && actualUserDto.Name == "testN"
            && actualUserDto.Description == "testD"
            );
    }

    IUserService GetUserService()
    {
        var mockContext = new Mock<IUnitOfWork>();
        var expectedUser = new User() { UserID = 1, Name = "testN", Email = "testD", UserType = 2 };
        var mockDbSet = new Mock<IUserRepository>();
        mockDbSet.Setup(z =>
            z.Find(
                It.IsAny<Func<User, bool>>(),
                It.IsAny<int>(),
                It.IsAny<int>()))
              .Returns(
                new List<User>() { expectedUser }
                );
        mockContext
            .Setup(context =>
                context.Users)
            .Returns(mockDbSet.Object);

        IHistoryService userService = new HistoryService(mockContext.Object);

        return userService;
    }
}
}
