using Domain.Entities;

namespace Application.Interfaces;

public interface IGameRepository : IRepository<Game>
{
	public Task<Game> GetById(Guid id);
	public Task<IQueryable<Game>> GetByName(string name);
}