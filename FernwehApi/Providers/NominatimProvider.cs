using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FernwehApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FernwehApi.Providers;

public class NominatimProvider : INominatimProvider
{
	private readonly IConfiguration _config;
	private readonly string _nominatimApiUrl;

	public NominatimProvider(IConfiguration config)
	{
		_config = config;
		_nominatimApiUrl = _config.GetValue<string>("NominatimApi");
	}

	public async Task<List<NominatimSearchResponse>?> ExtractNominatimData(string query)
	{
		var client = new HttpClient();
		client.BaseAddress = new Uri(_nominatimApiUrl);
		client.DefaultRequestHeaders.UserAgent.ParseAdd("ExploreNoteApi");
		var response = await client.GetAsync($"search?format=json&q={query}");
		var json = await response.Content.ReadAsStringAsync();
		var result = JsonConvert.DeserializeObject<List<NominatimSearchResponse>>(json);
		return result;
	}
}
