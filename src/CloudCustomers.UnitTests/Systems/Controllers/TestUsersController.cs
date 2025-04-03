using CloudCustomers.API;
using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
		// Arrange
		var mockUserService = new Mock<IUsersService>();
		var userController = new UsersController(mockUserService.Object);

		// Act
		var result = (OkObjectResult)await userController.GetAll();

		// Assert	
		result.StatusCode.Should().Be(200);
	}

	[Fact]
	public async Task Get_OnSuccess_InvokesUserService()
	{
		var mockUserService = new Mock<IUsersService>();
		mockUserService.Setup(service => service.GetAllUsersAsync())
			.ReturnsAsync(new List<User>()); 
		
		// Arrange
		var userController = new UsersController(mockUserService.Object);

		// Act
		var result = (OkObjectResult)await userController.GetAll();

		// Assert	
		result.StatusCode.Should().Be(200);
	}

	[Fact]
	public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
	{
		var mockUserService = new Mock<IUsersService>();
		mockUserService.Setup(service => service.GetAllUsersAsync())
			.ReturnsAsync(new List<User>());

		// Arrange
		var userController = new UsersController(mockUserService.Object);

		// Act
		var result = await userController.GetAll();

		// Assert	
		mockUserService.Verify(
			service => service.GetAllUsersAsync(), 
			Times.Once);


	}
}
