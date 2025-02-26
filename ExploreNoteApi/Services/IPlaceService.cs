using System.Collections.Generic;
using System.Threading.Tasks;
using ExploreNoteApi.Models;
using ExploreNoteApi.OsmModels;

namespace ExploreNoteApi.Services;

public interface IPlaceService
{
	Task<List<PlaceResponseDto>> ExtractPlaces(City city, Amenity amenity);
}
