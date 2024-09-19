using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FernwehApi.OsmModels;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Amenity
{
	Bar,
	Biergarten,
	Cafe,
	// FIXME : OSM Search not working with _
	[Display(Name = "fast_food")]
	FastFood,
	[Display(Name = "food_court")]
	FoodCourt,
	[Display(Name = "ice_cream")]
	IceCream,
	Pub
}
