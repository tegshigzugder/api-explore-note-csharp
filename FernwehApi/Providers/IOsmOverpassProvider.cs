using System.Threading.Tasks;
using FernwehApi.OsmModels;

namespace FernwehApi.Providers;

public interface IOsmOverpassProvider
{
	Task<OverpassResponse> OnGetSearchText(City city, Amenity amenity);
}
