using PackApi.Models.Database;

namespace FernwehApi.Database.Models;
public class User : AuditableEntity
{
	public int Id { get; set; }
	public string Username { get; set; }
	public string Email { get; set; }
	public string PasswordHash { get; set; }
}
