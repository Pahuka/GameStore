using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFData.Repository;

public class GameRepository : IGameRepository
{
	private readonly AppDbContext _dbContext;

	public GameRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<bool> Create(Game entity, CancellationToken cancellationToken)
	{
		await _dbContext.AddAsync(entity, cancellationToken);
		return _dbContext.SaveChangesAsync(cancellationToken).IsCompletedSuccessfully;
	}

	public async Task<Game> Update(Game entity, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task<bool> Delete(Game entity, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task<IQueryable<Game>> GetAll()
	{
		return _dbContext.Games.AsQueryable();
	}

	public async Task<Game> GetById(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<Game> GetByName(string name)
	{
		throw new NotImplementedException();
	}
}