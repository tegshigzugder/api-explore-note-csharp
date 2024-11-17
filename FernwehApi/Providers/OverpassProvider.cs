using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FernwehApi.OsmModels;
using Microsoft.Extensions.Configuration;

namespace FernwehApi.Providers;

public class OverpassProvider : IOverpassProvider
{
	private readonly IConfiguration _config;
	private readonly string _overpassApiUrl;

	public OverpassProvider(IConfiguration config)
	{
		_config = config;
		_overpassApiUrl = _config.GetValue<string>("OverpassApi");
	}

	public async Task<OverpassResponse?> OnGetSearchText(Amenity amenity, long areaId)
	{
		using var client = new HttpClient();

		var query = @$"
				[out:json][timeout:25];
				area(id:{areaId})->.searchArea;
				node[amenity={amenity.ToString().ToLower()}](area.searchArea);
				out geom;";

		var content = new StringContent(query, Encoding.UTF8, "application/json");
		content.Headers.ContentType =
			new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

		var response = await client.PostAsync(_overpassApiUrl + "interpreter", content);

		if (!response.IsSuccessStatusCode) return null;
		var result = await response.Content.ReadAsStringAsync();
		var options = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		};
		var listPlaces = JsonSerializer.Deserialize<OverpassResponse>(result, options);
		return listPlaces;
	}
}
