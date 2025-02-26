using System.Threading.Tasks;
using ExploreNoteApi.Models;

namespace ExploreNoteApi.Services;

public interface IUserService
{
	Task<ServiceResponseDto> CreateUserAsync(string username, string email, string password);
	Task<ServiceResponseDto> AuthenticateUserAsync(string email, string password);
}
