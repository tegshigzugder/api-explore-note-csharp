using System.Collections.Generic;
using System.Threading.Tasks;
using FernwehApi.Models;
using FernwehApi.OsmModels;

namespace FernwehApi.Services;

public interface IPlaceService
{
	/// <summary>
	///
	/// </summary>
	/// <param name="city"></param>
	/// <param name="amenity"></param>
	/// <returns></returns>
	Task<List<PlaceResponseDto>> Search(City city, Amenity amenity, PlaceSource source);

	Task<List<PlaceResponseDto>> GetPlacesOfInterest(City city, Amenity amenity);
}
