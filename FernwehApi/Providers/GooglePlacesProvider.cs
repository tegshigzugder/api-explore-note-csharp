using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FernwehApi.Database.Models;
using Microsoft.Extensions.Configuration;

namespace FernwehApi.Providers;

public class GooglePlacesProvider : IGooglePlacesProvider
{
	private readonly IConfiguration _config;
	private readonly string KEY;
	private readonly string URL = "https://places.googleapis.com/v1/places:searchText";

	public GooglePlacesProvider(IConfiguration config)
	{
		_config = config;
		KEY = _config["Google:PlacesApiKey"];
	}

	public async Task<List<Place>> OnGetSearchText(string city, string amenity)
	{
		var fieldsList = new List<string>{
			"places.rating",
			"places.userRatingCount",
			"places.formattedAddress",
			"places.displayName"
		};

		var fields = string.Join(",", fieldsList);
		var input = Uri.EscapeDataString($"{amenity} in {city}");

		string requestBody = @$"{{ ""textQuery"": ""{input}"" }}";
		var request = new HttpRequestMessage(HttpMethod.Post, URL);
		request.Headers.Add("X-Goog-Api-Key", KEY);
		request.Headers.Add("X-Goog-FieldMask", fields);
		request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");


		using var client = new HttpClient();
		var response = await client.SendAsync(request);

		// Check if the request was successful (status code 200)
		if (response.IsSuccessStatusCode)
		{
			// Read and display the response content
			string result = await response.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			var listPlaces = JsonSerializer.Deserialize<List<Place>>(result, options);
			return listPlaces;
		}
		else
		{
			// Display error message if the request was not successful
			Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
		}
		return [];
	}
}
