using Application.Implementations;
using Application.Response;

namespace Application.Interfaces;

public interface IGameService : IService<GameViewModel>
{
	public Task<IResponse<bool>> DeleteById(Guid id);
	public Task<IResponse<IEnumerable<GameViewModel>>> GetByName(string name);
}