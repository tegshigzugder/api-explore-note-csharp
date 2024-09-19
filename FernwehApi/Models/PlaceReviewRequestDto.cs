using System.Collections.Generic;

public class PlaceReviewRequestDto
{
	public string Location { get; set; }
	public string Name { get; set; }
	public int Rating { get; set; }
	public string Comment { get; set; }
	public List<PlaceItemReviewRequestDto> PlaceItemReviews { get; set; }
}
