using System.Collections.Generic;
using System.Threading.Tasks;
using ExploreNoteApi.Models;

namespace ExploreNoteApi.Providers;

public interface INominatimProvider
{
	Task<List<NominatimSearchResponse>?> ExtractNominatimData(string query);
}
