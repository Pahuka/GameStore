using Application.Response;

namespace Application.Interfaces;

public interface IGenreService : IService<IGenreViewModel>
{
	public Task<IResponse<bool>> DeleteById(Guid id);
	public Task<IResponse<bool>> DeleteByName(string name);
}