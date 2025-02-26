using System.Collections.Generic;

namespace ExploreNoteApi.Services;

public interface IEnumService
{
	List<string> GetAmenities();
	List<string> GetCities();
}
