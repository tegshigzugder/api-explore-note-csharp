using System.Collections.Generic;

namespace FernwehApi.Services;

public interface IEnumService
{
	List<string> GetAmenities();
	List<string> GetCities();
}
