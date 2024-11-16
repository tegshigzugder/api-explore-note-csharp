using System.Collections.Generic;
using System.Threading.Tasks;
using FernwehApi.Models;
using FernwehApi.OsmModels;

namespace FernwehApi.Services;

public interface IPlaceService
{
	Task<List<PlaceResponseDto>> GetPlacesOfInterest(City city, Amenity amenity);
}
