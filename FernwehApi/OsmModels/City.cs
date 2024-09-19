using System.Text.Json.Serialization;

namespace FernwehApi.OsmModels;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum City
{
	Berlin,
	Hamburg,
	Munich,
	Cologne,
	Frankfurt,
	Stuttgart,
	Düsseldorf,
	Dortmund,
	Essen,
	Leipzig,
	Bremen,
	Dresden
}
