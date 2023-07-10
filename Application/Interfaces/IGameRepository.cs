using Domain.Entities;

namespace Application.Interfaces;

public interface IGameRepository : IRepository<Game>
{
	Task<Game> GetById(Guid id);
	Task<Game> GetByName(string name);
}