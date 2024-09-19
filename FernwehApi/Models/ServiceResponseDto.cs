public class ServiceResponseDto
{
	public bool Success { get; set; }
	public string Message { get; set; }
	public string Token { get; set; } // For the JWT token in the login response
}
