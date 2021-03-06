using System;
using System.Collections.Generic;

using Example.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

using Example.Business.Services;
using Example.Domain.Entities;
using Example.Helpers;

namespace Example.Api.Tests.Unit
{
    public class UsersControllerTests
    {
        private Mock<IUsersService> usersServiceMock { get; set; }

        public UsersControllerTests()
        {
            var repository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Mock };

            // Create a mock using the repository settings
            this.usersServiceMock = repository.Create<IUsersService>();
        }

        [Fact]
        public void GetAuthor_should_return_a_200OK_if_everything_goes_well()
        {
            // Arrange
            this.usersServiceMock
                .Setup(m => m.GetUsersList(1, 1))
                .Returns(new List<User>());
            var authorsCtrlr = new UsersController(this.usersServiceMock.Object);
            var usersResourceParameter = new UsersResourceParameter
                                             {
                                                 PageNumber = 1,
                                                 PageSize = 10
                                             };

            // Act
            var result = authorsCtrlr.GetUserList(usersResourceParameter);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAuthor_should_return_a_BadRequest_if_Guid_is_invalid()
        {
            // Arrange
            this.usersServiceMock
                .Setup(m => m.GetUsersList(1, 10))  // will set up CommandBase.Execute
                .Returns(new List<User>());
            var authorsCtrlr = new UsersController(this.usersServiceMock.Object);

            // Act
            var result = authorsCtrlr.GetUser(Guid.Empty);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
