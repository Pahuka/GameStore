using Domain.Entities;

namespace Application.Interfaces;

public interface IGenreRepository : IRepository<Genre>
{
	Task<Genre> GetById(int id);
	Task<Genre> GetByName(string name);
}