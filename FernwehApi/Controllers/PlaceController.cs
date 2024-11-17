using System.Collections.Generic;
using System.Threading.Tasks;
using FernwehApi.Models;
using FernwehApi.OsmModels;
using FernwehApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FernwehApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaceController : ControllerBase
{
	private readonly ILogger<PlaceController> _logger;
	private readonly IPlaceService _placeService;
	private readonly IEnumService _enumService;

	public PlaceController(
		ILogger<PlaceController> logger,
		IPlaceService placeService,
		IEnumService enumService)
	{
		_logger = logger;
		_placeService = placeService;
		_enumService = enumService;
	}

	[HttpGet("enums")]
	public ActionResult<EnumsDto> GetEnums()
	{
		var amenities = _enumService.GetAmenities();
		var cities = _enumService.GetCities();

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
			var places = await _placeService.ExtractPlaces(city, amenity);
			return Ok(new ResponseWrapper<List<PlaceResponseDto>>(true, "Success", places));
		}
		catch (Exception ex)
		{
			return BadRequest(new ResponseWrapper<string>(false, ex.Message, null, "ERROR_CODE"));
		}
	}
}
