using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FernwehApi.OsmModels;
using Microsoft.Extensions.Configuration;

namespace FernwehApi.Providers;

public class OsmOverpassProvider : IOsmOverpassProvider
{
	private readonly IConfiguration _config;
	private readonly string URL = "https://overpass-api.de/api/interpreter";

	public OsmOverpassProvider(IConfiguration config)
	{
		_config = config;
	}

	public async Task<OverpassResponse> OnGetSearchText(City city, Amenity amenity)
	{
		using var client = new HttpClient();

		// TODO: transform geocodeArea into area id into
		// {{geocodeArea:Leipzig-Center}}->.searchArea;
		// area(id:3606273540)->.searchArea;
		// Leipzig-Center is 3606273540
		// another possibility is area[name="Leipzig"]->.searchArea;
		// need to -Center though

		var id = 3606273540;

		var temp = amenity.ToString().ToLower();

		var query = @$"
				[out:json][timeout:25];
				area(id:{id})->.searchArea;
				node[amenity={temp}](area.searchArea);
				out geom;";

		var content = new StringContent(query, Encoding.UTF8, "application/json");
		content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

		// Send the POST request
		HttpResponseMessage response = await client.PostAsync(URL, content);

		if (response.IsSuccessStatusCode)
		{
			// Read and display the response content
			string result = await response.Content.ReadAsStringAsync();
			// WriteToFile(result);
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			var listPlaces = JsonSerializer.Deserialize<OverpassResponse>(result, options);
			return listPlaces;
		}
		else
		{
			// Display error message if the request was not successful
			Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
		}
		return new OverpassResponse() { };
	}

	private static void WriteToFile(string result)
	{
		var dt = string.Format("{0:s}", DateTime.Now);
		var fileName = "Results/" + dt + ".json";
		File.WriteAllText(fileName, result);
	}
}
