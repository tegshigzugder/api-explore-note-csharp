using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FernwehApi.Models;
using FernwehApi.OsmModels;
using FernwehApi.Providers;

namespace FernwehApi.Services;

public class PlaceService : IPlaceService
{
	private readonly IOverpassProvider _overpassProvider;
	private readonly INominatimProvider _nominatimProvider;

	public PlaceService(
		IOverpassProvider overpassProvider,
		INominatimProvider nominatimProvider)
	{
		_overpassProvider = overpassProvider;
		_nominatimProvider = nominatimProvider;
	}

	public async Task<List<PlaceResponseDto>> ExtractPlaces(City city, Amenity amenity)
	{
		var areaId = await ExtractAreaId(city);
		var places = await ExtractPlaces(amenity, areaId);
		return places;
	}

	private async Task<List<PlaceResponseDto>> ExtractPlaces(Amenity amenity, long areaId)
	{
		var overpassResponse = await _overpassProvider.OnGetSearchText(amenity, areaId);
		if (overpassResponse == null)
		{
			throw new InvalidOperationException("OverpassResponse is null");
		}

		if (overpassResponse.Elements.Count == 0)
		{
			throw new InvalidOperationException("OverpassResponse.Elements is empty");
		}

		return PlaceResponseDto.ConvertToPlaceResponseDto(overpassResponse.Elements);
	}

	private async Task<long> ExtractAreaId(City city)
	{
		var nominatimData = await _nominatimProvider.ExtractNominatimData(city.ToString());
		if (nominatimData == null || nominatimData.Count == 0)
		{
			throw new InvalidOperationException("NominatimData is null or empty");
		}

		var areaData = nominatimData.FirstOrDefault();

		if (areaData == null)
		{
			throw new InvalidOperationException("areaData is null");
		}

		var areaId = areaData.OsmId;

		if (areaData.OsmType == "relation")
		{
			areaId += 3600000000;
		}

		return areaId;
	}
}
