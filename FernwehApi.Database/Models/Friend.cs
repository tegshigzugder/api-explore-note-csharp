using System.ComponentModel.DataAnnotations.Schema;
using PackApi.Models.Database;

namespace FernwehApi.Database.Models;
public class Friend : AuditableEntity
{
	public int Id { get; set; }
	public int UserId { get; set; }
	public int FriendId { get; set; }
	[ForeignKey("UserId")]
	public User User { get; set; }
	[ForeignKey("FriendUserId")]
	public User FriendUser { get; set; }
}
