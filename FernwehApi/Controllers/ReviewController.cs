using System.Collections.Generic;
using System.Threading.Tasks;
using FernwehApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FernwehApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase
{
	private readonly ILogger<ServiceController> _logger;
	private readonly IReviewService _reviewService;

	public ReviewController(
		ILogger<ServiceController> logger,
		IReviewService reviewService)
	{
		_logger = logger;
		_reviewService = reviewService;
	}

	[HttpPost("addreview/{userId}/{placeId}")]
	public IActionResult AddReview([FromRoute] int userId, [FromRoute] long placeId,
		[FromBody] PlaceReviewRequestDto placeRequestDto)
	{
		_reviewService.AddReview(userId, placeId, placeRequestDto);
		return Ok();
	}

	[HttpGet("getreview/{userId}/{placeId}")]
	public async Task<ActionResult<List<PlaceDetailsResponseDto>>> GetReview([FromRoute] int userId = 1,
		[FromRoute] long placeId = 1)
	{
		var review = await _reviewService.GetReview(userId, placeId);
		return Ok(review);
	}
}
