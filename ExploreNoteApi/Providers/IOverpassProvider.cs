using System.Threading.Tasks;
using ExploreNoteApi.OsmModels;

namespace ExploreNoteApi.Providers;

public interface IOverpassProvider
{
	Task<OverpassResponse?> OnGetSearchText(Amenity amenity, long areaId);
}
