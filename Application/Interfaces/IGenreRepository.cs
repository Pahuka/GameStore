using Domain.Entities;

namespace Application.Interfaces;

public interface IGenreRepository : IRepository<Genre>
{
	Task<Genre> GetById(Guid id);
	Task<Genre> GetByName(string name);
}