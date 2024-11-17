public class UserClient
{
	private readonly HttpClient _httpClient;

	public UserClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}
}
