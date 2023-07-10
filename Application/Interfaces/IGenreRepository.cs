using Domain.Entities;

namespace Application.Interfaces;

public interface IGenreRepository : IRepository<Genre>
{
	public Task<Genre> GetById(Guid id);
	public Task<Genre> GetByName(string name);
}