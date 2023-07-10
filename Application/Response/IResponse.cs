using Domain.Enums;

namespace Application.Response;

public interface IResponse<T>
{
	T Data { get; set; }
	StatusCode StatusCode { get; set; }
	public string Description { get; set; }
}