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
}
