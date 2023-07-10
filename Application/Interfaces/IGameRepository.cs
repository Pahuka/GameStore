using Domain.Entities;

namespace Application.Interfaces;

public interface IGameRepository : IRepository<Game>
{
	Task<Game> GetById(int id);
	Task<Game> GetByName(string name);
}