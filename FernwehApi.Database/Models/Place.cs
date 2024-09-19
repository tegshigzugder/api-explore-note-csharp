using PackApi.Models.Database;

namespace FernwehApi.Database.Models;
public class Place : AuditableEntity
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Location { get; set; }
	public long NodeId { get; set; }
	public ICollection<PlaceItem> PlaceItems { get; set; }
	public ICollection<PlaceReview> PlaceReviews { get; set; }
}
