using System.ComponentModel.DataAnnotations.Schema;
using PackApi.Models.Database;

namespace FernwehApi.Database.Models;
public class PlaceItemReview : AuditableEntity
{
	public int Id { get; set; }
	public int Rating { get; set; }
	public string Comment { get; set; }
	[ForeignKey("PlaceItemId")]
	public PlaceItem PlaceItem { get; set; }
	// [ForeignKey("UserId")]
	// public User User { get; set; }
	public ICollection<Photo> Photos { get; set; }
}