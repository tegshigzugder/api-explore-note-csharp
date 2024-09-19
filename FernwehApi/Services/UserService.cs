using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using FernwehApi.Database.Models;
using FernwehApi.Repositories;
using Microsoft.Extensions.Logging;

namespace FernwehApi.Services;

public class UserService : IUserService
{
	private readonly ILogger<UserService> _logger;
	private readonly IUserRepository _userRepository;
	// private readonly JwtSettings _jwtSettings;

	public UserService(
			ILogger<UserService> logger,
			IUserRepository userRepository
			// JwtSettings jwtSettings
			)
	{
		_logger = logger;
		_userRepository = userRepository;
		// _jwtSettings = jwtSettings;
	}

	public async Task<ServiceResponseDto> CreateUserAsync(string username, string email, string password)
	{
		_logger.LogInformation("Creating user with username: {Username}, email: {Email}", username, email);

		// Check if the username already exists
		var existingUserByUsername = await _userRepository.GetUserByUsernameAsync(username);
		if (existingUserByUsername != null)
		{
			_logger.LogWarning("Username {Username} is already taken.", username);
			return new ServiceResponseDto
			{
				Success = false,
				Message = "Username is already taken."
			};
		}

		// Check if the email already exists
		var existingUserByEmail = await _userRepository.GetUserByEmailAsync(email);
		if (existingUserByEmail != null)
		{
			_logger.LogWarning("Email {Email} is already taken.", email);
			return new ServiceResponseDto
			{
				Success = false,
				Message = "Email is already taken."
			};
		}

		await Task.Delay(100); // Simulate async work

		await _userRepository.AddUserAsync(new User
		{
			Username = username,
			Email = email,
			PasswordHash = password
		});

		return new ServiceResponseDto
		{
			Success = true,
			Message = "User created successfully"
		};
	}

	public async Task<ServiceResponseDto> AuthenticateUserAsync(string email, string password)
	{
		_logger.LogInformation("Authenticating user with email: {Email}", email);
		var user = await _userRepository.GetUserByEmailAsync(email);

		if (user == null)
		{
			return new ServiceResponseDto
			{
				Success = false,
				Message = "User not found"
			};
		}

		if (user.PasswordHash != password)
		{
			return new ServiceResponseDto
			{
				Success = false,
				Message = "Invalid password"
			};
		}

		var token = GenerateJwtToken(user);

		return new ServiceResponseDto
		{
			Success = true,
			Message = "User authenticated successfully",
			Token = token
		};
	}

	private string GenerateJwtToken(User user)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		// var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
		// var tokenDescriptor = new SecurityTokenDescriptor
		// {
		// 	Subject = new ClaimsIdentity(new[]
		// 	{
		// 		new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
		// 		new Claim(ClaimTypes.Name, user.Username)
		// 	}),
		// 	Expires = DateTime.UtcNow.AddHours(1),
		// 	SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		// };
		// var token = tokenHandler.CreateToken(tokenDescriptor);
		return ""; //tokenHandler.WriteToken(token);
	}
}
