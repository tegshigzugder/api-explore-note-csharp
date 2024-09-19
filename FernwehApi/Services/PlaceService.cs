using System.Collections.Generic;
using System.Threading.Tasks;
using FernwehApi.Models;
using FernwehApi.OsmModels;
using FernwehApi.Providers;

namespace FernwehApi.Services;

public class PlaceService : IPlaceService
{
	private readonly IGooglePlacesProvider _googleMapsProvider;
	private readonly IOsmOverpassProvider _osmOverpassProvider;

	public PlaceService(
		IGooglePlacesProvider googleMapsProvider,
		IOsmOverpassProvider osmOverpassProvider)
	{
		_googleMapsProvider = googleMapsProvider;
		_osmOverpassProvider = osmOverpassProvider;
	}

	public async Task<List<PlaceResponseDto>> Search(City city, Amenity amenity, PlaceSource source)
	{

		switch (source)
		{
			case PlaceSource.OpenStreetMap:
				var osmResults = await _osmOverpassProvider.OnGetSearchText(city, amenity);
				var osmPois = PlaceResponseDto.ConvertToPlaceResponseDto(osmResults.Elements);
				return osmPois;
			case PlaceSource.GoogleMaps:
				var results = await _googleMapsProvider.OnGetSearchText(city.ToString(), amenity.ToString());
				// var placesPois = PlaceResponseDto.ConvertToPlaceResponseDto(results);
				// TODO: implement conversion and test googlemaps source
				return null;
			default:
				return null;
		}
	}

	public async Task<List<PlaceResponseDto>> GetPlacesOfInterest(City city, Amenity amenity)
	{
		var overpassResponse = await _osmOverpassProvider.OnGetSearchText(city, amenity);
		return PlaceResponseDto.ConvertToPlaceResponseDto(overpassResponse.Elements);
	}
}
