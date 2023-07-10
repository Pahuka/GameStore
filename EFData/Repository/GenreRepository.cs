using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFData.Repository;

public class GenreRepository : IGenreRepository
{
	private readonly AppDbContext _appDbContext;

	public GenreRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	public async Task<bool> Create(Genre entity)
	{
		await _appDbContext.Genres.AddAsync(entity);
		return _appDbContext.SaveChangesAsync().IsCompletedSuccessfully;
	}

	public async Task<Genre> Update(Genre entity)
	{
		_appDbContext.Genres.Update(entity);
		await _appDbContext.SaveChangesAsync();

		return entity;
	}

	public async Task<bool> Delete(Genre entity)
	{
		_appDbContext.Genres.Remove(entity);

		return _appDbContext.SaveChangesAsync().IsCompletedSuccessfully;
	}

	public async Task<IQueryable<Genre>> GetAll()
	{
		return _appDbContext.Genres
			.Include(x => x.Games)
			.AsQueryable();
	}

	public async Task<Genre> GetById(Guid id)
	{
		return await _appDbContext.Genres.FindAsync(id);
	}

	public async Task<Genre> GetByName(string name)
	{
		return await _appDbContext.Genres.FindAsync(name);
	}
}