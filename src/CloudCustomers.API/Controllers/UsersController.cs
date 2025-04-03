using CloudCustomers.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUsersService _usersService;
    public UsersController(IUsersService usersService)
    {
		_usersService = usersService;
	}

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _usersService.GetAllUsersAsync();
        return Ok(users);
    }
}
