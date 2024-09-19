using Microsoft.EntityFrameworkCore;
using FernwehApi.Database.Models;

namespace FernwehApi.Repositories;

/// <inheritdoc />
public class UserRepository : IUserRepository
{
	private readonly FernwehDbContext _dbContext;

	public UserRepository(FernwehDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	/// <inheritdoc />
	public async Task AddUserAsync(User user)
	{
		await _dbContext.Users.AddAsync(user);
		await _dbContext.SaveChangesAsync();
	}

	/// <inheritdoc />
	public async Task<User?> GetUserByEmailAsync(string email)
	{
		return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
	}

	/// <inheritdoc />
	public async Task<User?> GetUserByUsernameAsync(string username)
	{
		return await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
	}
}
