using PackApi.Models.Database;

namespace FernwehApi.Database.Models;

public class Photo : AuditableEntity
{
	public int Id { get; set; }

	public string Url { get; set; }

	// TODO: fix photos later
	// [ForeignKey("PlaceReview")]
	// public PlaceReview PlaceReview { get; set; }

	// [ForeignKey("PlaceItemReview")]
	// public PlaceItemReview PlaceItemReview { get; set; }
}
