using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using FernwehApi.OsmModels;

namespace FernwehApi.Models;
public class PlaceResponseDto
{
	public string name { get; set; }
	public string amenity { get; set; }
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PlaceSource source { get; set; }
	public long nodeId { get; set; }

	public double lat { get; set; }
	public double lon { get; set; }
	public static List<PlaceResponseDto> ConvertToPlaceResponseDto(List<Element> elements)
	{
		return (from element in elements
				select new PlaceResponseDto
				{
					name = element.Tags.Name,
					amenity = element.Tags.Amenity,
					source = PlaceSource.OpenStreetMap,
					nodeId = element.Id,
					lat = element.Lat,
					lon = element.Lon
				}).ToList();
	}
}
