using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class UserClient
{
	private readonly HttpClient _httpClient;

	public UserClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<User> GetUserByEmailAsync(string email)
	{
		var response = await _httpClient.GetAsync($"api/users/email/{email}");
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadFromJsonAsync<User>();
	}

	public async Task CreateUserAsync(User user)
	{
		var response = await _httpClient.PostAsJsonAsync("api/users", user);
		response.EnsureSuccessStatusCode();
	}
}
