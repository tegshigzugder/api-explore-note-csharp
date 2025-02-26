using System.Text.Json.Serialization;

namespace ExploreNoteApi.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PlaceSource
{
	OpenStreetMap,
	GoogleMaps
}
