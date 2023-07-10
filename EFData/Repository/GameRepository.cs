using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFData.Repository;

public class GameRepository : IGameRepository
{
	private readonly AppDbContext _appDbContext;

	public GameRepository(AppDbContext appAppDbContext)
	{
		_appDbContext = appAppDbContext;
	}

	public async Task<bool> Create(Game entity)
	{
		await _appDbContext.Games.AddAsync(entity);

		return _appDbContext.SaveChangesAsync().IsCompletedSuccessfully;
	}

	public async Task<Game> Update(Game entity)
	{
		_appDbContext.Games.Update(entity);
		await _appDbContext.SaveChangesAsync();

		return entity;
	}

	public async Task<bool> Delete(Game entity)
	{
		_appDbContext.Games.Remove(entity);

		return _appDbContext.SaveChangesAsync().IsCompletedSuccessfully;
	}

	public async Task<IQueryable<Game>> GetAll()
	{
		return _appDbContext.Games
			.Include(x => x.Genres)
			.AsQueryable();
	}

	public async Task<Game> GetById(Guid id)
	{
		return await _appDbContext.Games
			.FirstOrDefaultAsync(x => x.Id == id);
	}

	public async Task<Game> GetByName(string name)
	{
		return await _appDbContext.Games
			.FirstOrDefaultAsync(x => x.Name == name);
	}
}