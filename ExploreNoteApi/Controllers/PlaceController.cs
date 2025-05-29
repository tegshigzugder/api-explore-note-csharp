using System.Collections.Generic;
using System.Threading.Tasks;
using ExploreNoteApi.Models;
using ExploreNoteApi.OsmModels;
using ExploreNoteApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExploreNoteApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaceController(
	ILogger<PlaceController> logger,
	IPlaceService placeService,
	IEnumService enumService)
	: ControllerBase
{
	private readonly ILogger<PlaceController> _logger = logger;

	[HttpGet("enums")]
	public ActionResult<EnumsDto> GetEnums()
	{
		var amenities = enumService.GetAmenities();
		var cities = enumService.GetCities();

		var enumsDto = new EnumsDto
		{
			amenities = amenities,
			cities = cities
		};

		return Ok(enumsDto);
	}

	[HttpGet("places")]
	public async Task<ActionResult> GetPlaces(City city, Amenity amenity)
	{
		try
		{
			var places = await placeService.ExtractPlaces(city, amenity);
			return Ok(new ResponseWrapper<List<PlaceResponseDto>>(true, "Success", places));
		}
		catch (Exception ex)
		{
			return BadRequest(new ResponseWrapper<string>(false, ex.Message, null, "ERROR_CODE"));
		}
	}
}
