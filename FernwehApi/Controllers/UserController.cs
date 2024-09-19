using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FernwehApi.Models;
using FernwehApi.Services;

namespace FernwehApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	private readonly ILogger<UserController> _logger;
	private readonly IUserService _userService;

	public UserController(ILogger<UserController> logger, IUserService userService)
	{
		_logger = logger;
		_userService = userService;
	}

	/// <summary>
	/// Create a new user.
	/// </summary>
	/// <param name="request">The user signup request containing username, email, and password.</param>
	/// <returns>A response indicating the result of the signup operation.</returns>
	[HttpPost("signup")]
	public async Task<IActionResult> Signup([FromBody] SignupRequestDto request)
	{
		var result = await _userService.CreateUserAsync(request.Username, request.Email, request.Password);
		if (result.Success)
		{
			return Ok(result);
		}
		return BadRequest(result);
	}

	/// <summary>
	/// Authenticate a user and return a JWT token.
	/// </summary>
	/// <param name="request">The user login request containing email and password.</param>
	/// <returns>A response containing the JWT token if authentication is successful.</returns>
	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
	{
		var result = await _userService.AuthenticateUserAsync(request.Email, request.Password);
		if (result.Success)
		{
			return Ok(result);
		}
		return Unauthorized(result);
	}
}
