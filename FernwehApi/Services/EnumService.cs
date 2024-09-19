using System.Collections.Generic;
using System.Linq;
using FernwehApi.OsmModels;

namespace FernwehApi.Services;

public class EnumService : IEnumService
{
	public List<string> GetAmenities()
	{
		return Enum.GetNames(typeof(Amenity)).ToList();
	}

	public List<string> GetCities()
	{
		return Enum.GetNames(typeof(City)).ToList();
	}
}
