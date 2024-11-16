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
	private readonly IPlaceService _placesService;
	private readonly IEnumService _enumService;

	public PlaceController(
		ILogger<PlaceController> logger,
		IPlaceService placesService,
		IEnumService enumService)
	{
		_logger = logger;
		_placesService = placesService;
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
	public async Task<ActionResult<List<PlaceResponseDto>>> GetPlaces(City city, Amenity amenity)
	{
		var placeResponseDto = await _placesService.GetPlacesOfInterest(city, amenity);
		return Ok(placeResponseDto);
	}
}
