using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services;

public interface IUsersService
{
	// Define methods for user-related operations
	public Task<List<User>> GetAllUsersAsync();
}

public class UsersService : IUsersService
{
	public UsersService()
	{
		
	}

	Task<List<User>> IUsersService.GetAllUsersAsync()
	{
		throw new NotImplementedException();
	}
}
