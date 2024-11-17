using System.Collections.Generic;
using Newtonsoft.Json;

namespace FernwehApi.Models;

public class NominatimSearchResponse
{
	[JsonProperty("place_id")] public int PlaceId { get; set; }

	[JsonProperty("licence")] public string Licence { get; set; }

	[JsonProperty("osm_type")] public string OsmType { get; set; }

	[JsonProperty("osm_id")] public long OsmId { get; set; }

	[JsonProperty("lat")] public string Latitude { get; set; }

	[JsonProperty("lon")] public string Longitude { get; set; }

	[JsonProperty("class")] public string Class { get; set; }

	[JsonProperty("type")] public string Type { get; set; }

	[JsonProperty("place_rank")] public int PlaceRank { get; set; }

	[JsonProperty("importance")] public double Importance { get; set; }

	[JsonProperty("addresstype")] public string AddressType { get; set; }

	[JsonProperty("name")] public string Name { get; set; }

	[JsonProperty("display_name")] public string DisplayName { get; set; }

	[JsonProperty("boundingbox")] public List<string> BoundingBox { get; set; }
}
