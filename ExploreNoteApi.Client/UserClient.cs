namespace ExploreNoteApi.Client;

public class UserClient(HttpClient httpClient)
{
	private readonly HttpClient _httpClient = httpClient;
}
