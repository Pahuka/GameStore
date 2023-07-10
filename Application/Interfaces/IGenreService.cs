using Application.Response;

namespace Application.Interfaces;

public interface IGenreService : IService<IGenreViewModel>
{
	Task<IResponse<bool>> DeleteById(Guid id);
	Task<IResponse<bool>> DeleteByName(string name);
}