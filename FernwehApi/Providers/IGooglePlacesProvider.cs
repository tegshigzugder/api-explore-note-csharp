using System.Collections.Generic;
using System.Threading.Tasks;
using FernwehApi.Database.Models;

namespace FernwehApi.Providers;

public interface IGooglePlacesProvider
{
	Task<List<Place>> OnGetSearchText(string city, string amenity);
}
