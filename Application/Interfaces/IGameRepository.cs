using Domain.Entities;

namespace Application.Interfaces;

public interface IGameRepository : IRepository<Game>
{
	public Task<Game> GetById(Guid id);
	public Task<Game> GetByName(string name);
}