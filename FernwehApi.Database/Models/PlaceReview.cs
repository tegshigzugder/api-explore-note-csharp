using System.ComponentModel.DataAnnotations.Schema;
using PackApi.Models.Database;

namespace FernwehApi.Database.Models;
public class PlaceReview : AuditableEntity
{
	public int Id { get; set; }
	public int Rating { get; set; }
	public string Comment { get; set; }
	// [ForeignKey("UserId")]
	// public User User { get; set; }
	[ForeignKey("PlaceId")]
	public Place Place { get; set; }
	public ICollection<Photo> Photos { get; set; }
}
