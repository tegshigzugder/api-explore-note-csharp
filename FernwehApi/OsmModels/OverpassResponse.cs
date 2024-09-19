using System.Collections.Generic;

namespace FernwehApi.OsmModels;

public class OverpassResponse
{
	public double Version { get; set; }
	public string Generator { get; set; }
	public Osm3s Osm3s { get; set; }
	public List<Element> Elements { get; set; }
}
