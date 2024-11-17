namespace FernwehApi.Models;

public class ResponseWrapper<T>(bool success, string message, T data, string errorCode = null)
{
	public bool Success { get; set; } = success;
	public string Message { get; set; } = message;
	public T Data { get; set; } = data;
	public string ErrorCode { get; set; } = errorCode;
}
