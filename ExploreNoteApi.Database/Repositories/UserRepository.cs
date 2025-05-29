using ExploreNoteApi.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ExploreNoteApi.Database.Repositories;

/// <inheritdoc />
public class UserRepository(ExploreNoteDbContext dbContext) : IUserRepository
{
	/// <inheritdoc />
	public async Task AddUserAsync(User user)
	{
		await dbContext.Users.AddAsync(user);
		await dbContext.SaveChangesAsync();
	}

	/// <inheritdoc />
	public async Task<User?> GetUserByEmailAsync(string email)
	{
		return await dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
	}

	/// <inheritdoc />
	public async Task<User?> GetUserByUsernameAsync(string username)
	{
		return await dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
	}
}
