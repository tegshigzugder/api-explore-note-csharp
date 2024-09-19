using System.Text.Json.Serialization;

namespace FernwehApi.OsmModels;

public class Tags
{
	[JsonPropertyName("addr:city")]
	public string Addr_City { get; set; }

	[JsonPropertyName("addr:country")]
	public string Addr_Country { get; set; }

	[JsonPropertyName("addr:district")]
	public string Addr_District { get; set; }

	[JsonPropertyName("addr:full")]
	public string Addr_Full { get; set; }

	[JsonPropertyName("addr:hamlet")]
	public string Addr_Hamlet { get; set; }

	[JsonPropertyName("addr:housenumber")]
	public string Addr_Housenumber { get; set; }

	[JsonPropertyName("addr:neighbourhood")]
	public string Addr_Neighbourhood { get; set; }

	[JsonPropertyName("addr:place")]
	public string Addr_Place { get; set; }

	[JsonPropertyName("addr:postcode")]
	public string Addr_Postcode { get; set; }

	[JsonPropertyName("addr:state")]
	public string Addr_State { get; set; }

	[JsonPropertyName("addr:street")]
	public string Addr_Street { get; set; }

	[JsonPropertyName("addr:TW:dataset")]
	public string Addr_TW_Dataset { get; set; }

	[JsonPropertyName("amenity")]
	public string Amenity { get; set; }

	[JsonPropertyName("barrier")]
	public string Barrier { get; set; }

	[JsonPropertyName("created_by")]
	public string Created_By { get; set; }

	[JsonPropertyName("crossing")]
	public string Crossing { get; set; }

	[JsonPropertyName("highway")]
	public string Highway { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("natural")]
	public string Natural { get; set; }

	[JsonPropertyName("operator")]
	public string Operator { get; set; }

	[JsonPropertyName("place")]
	public string Place { get; set; }

	[JsonPropertyName("power")]
	public string Power { get; set; }

	[JsonPropertyName("source")]
	public string Source { get; set; }

	[JsonPropertyName("source:date")]
	public string Source_Date { get; set; }

	internal object?[] Select(Func<object, string> value)
	{
		throw new NotImplementedException();
	}
}
