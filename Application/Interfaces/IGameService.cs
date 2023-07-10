using Application.Response;

namespace Application.Interfaces;

public interface IGameService : IService<IGameViewModel>
{
	public Task<IResponse<bool>> DeleteById(Guid id);
	public Task<IResponse<bool>> DeleteByName(string name);
	public Task<IResponse<IGameViewModel>> GetByName(string name);
}