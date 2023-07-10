using Application.Interfaces;
using Domain.Entities;

namespace EFData.Repository;

public class GenreRepository : IGenreRepository
{
	private readonly AppDbContext _appDbContext;

	public GenreRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	public async Task<bool> Create(Genre entity, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task<Genre> Update(Genre entity, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task<bool> Delete(Genre entity, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task<IQueryable<Genre>> GetAll()
	{
		throw new NotImplementedException();
	}

	public async Task<Genre> GetById(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<Genre> GetByName(string name)
	{
		throw new NotImplementedException();
	}
}