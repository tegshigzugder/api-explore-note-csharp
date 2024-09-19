using System.Threading.Tasks;

namespace FernwehApi.Services;

public interface IUserService
{
	Task<ServiceResponseDto> CreateUserAsync(string username, string email, string password);
	Task<ServiceResponseDto> AuthenticateUserAsync(string email, string password);
}
