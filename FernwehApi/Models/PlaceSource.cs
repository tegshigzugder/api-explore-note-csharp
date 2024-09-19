using System.Text.Json.Serialization;

namespace FernwehApi.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PlaceSource
{
	OpenStreetMap,
	GoogleMaps
}
