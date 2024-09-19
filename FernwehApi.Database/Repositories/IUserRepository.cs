using FernwehApi.Database.Models;

namespace FernwehApi.Repositories;

/// <summary>
/// Interface for User repository to handle user-related operations.
/// </summary>
public interface IUserRepository
{
	/// <summary>
	/// Adds a new user asynchronously.
	/// </summary>
	/// <param name="user">The user to add.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	Task AddUserAsync(User user);

	/// <summary>
	/// Gets a user by their email asynchronously.
	/// </summary>
	/// <param name="email">The email of the user.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains the user if found; otherwise, null.</returns>
	Task<User?> GetUserByEmailAsync(string email);

	/// <summary>
	/// Gets a user by their username asynchronously.
	/// </summary>
	/// <param name="username">The username of the user.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains the user if found; otherwise, null.</returns>
	Task<User?> GetUserByUsernameAsync(string username);
}