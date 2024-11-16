using System.Collections.Generic;
using System.Threading.Tasks;
using FernwehApi.Models;

namespace FernwehApi.Providers;

public interface INominatimProvider
{
	Task<List<NominatimSearchResponse>?> ExtractNominatimData(string query);
}
