using System.Collections.Generic;
using System.Threading.Tasks;
using ExploreNoteApi.Models;
using ExploreNoteApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExploreNoteApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController(
	ILogger<ServiceController> logger,
	IReviewService reviewService)
	: ControllerBase
{
	private readonly ILogger<ServiceController> _logger = logger;

	[HttpPost("addreview/{userId:int}/{placeId:long}")]
	public IActionResult AddReview([FromRoute] int userId, [FromRoute] long placeId,
		[FromBody] PlaceReviewRequestDto placeRequestDto)
	{
		reviewService.AddReview(userId, placeId, placeRequestDto);
		return Ok();
	}

	[HttpGet("getallreviews")]
	public async Task<ActionResult<List<PlaceDetailsResponseDto>>> GetAllReviews()
	{
		var reviews = await reviewService.GetAllReviews();
		return Ok(reviews);
	}

	[HttpGet("getreview/{userId:int?}/{placeId:long?}")]
	public async Task<ActionResult<List<PlaceDetailsResponseDto>>> GetReview(
		[FromRoute] int userId,
		[FromRoute] long placeId)
	{
		var review = await reviewService.GetReview(userId, placeId);
		return Ok(review);
	}
}
