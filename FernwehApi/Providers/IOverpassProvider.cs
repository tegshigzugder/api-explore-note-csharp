using System.Threading.Tasks;
using FernwehApi.OsmModels;

namespace FernwehApi.Providers;

public interface IOverpassProvider
{
	Task<OverpassResponse?> OnGetSearchText(Amenity amenity, long areaId);
}
