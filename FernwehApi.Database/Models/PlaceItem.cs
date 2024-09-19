using System.ComponentModel.DataAnnotations.Schema;
using PackApi.Models.Database;

namespace FernwehApi.Database.Models;
public class PlaceItem : AuditableEntity
{
	public int Id { get; set; }
	public string Name { get; set; }
	public decimal Price { get; set; }

	[ForeignKey("PlaceId")]
	public Place Place { get; set; }
	public ICollection<PlaceItemReview> PlaceItemReviews { get; set; }
}
