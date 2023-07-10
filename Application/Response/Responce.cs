using Domain.Enums;

namespace Application.Response;

public class Responce<T> : IResponse<T>
{
	public T Data { get; set; }
	public StatusCode StatusCode { get; set; }
	public string Description { get; set; }
}