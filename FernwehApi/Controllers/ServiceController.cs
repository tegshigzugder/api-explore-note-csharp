using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FernwehApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceController : ControllerBase
{
	private readonly ILogger<ServiceController> _logger;
	public ServiceController(ILogger<ServiceController> logger)
	{
		_logger = logger;
	}

	// [Authorize]
	// TODO: add the [Authorize] attribute to secure this endpoint
	// add the bearer token to the request headers
	[HttpGet(Name = "GetDb")]
	public void GetDb()
	{
		;
	}
}
