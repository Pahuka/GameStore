using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Persistence.Repository;

public class GameRepository : IGameRepository
{
	private readonly ICurrentDbContext _dbContext;
	
	public GameRepository(ICurrentDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	public async Task<bool> Create(Game entity)
	{
		return _dbContext.Context.AddAsync(entity).IsCompletedSuccessfully;
	}

	public async Task<Game> Update(Game entity)
	{
		throw new NotImplementedException();
	}

	public async Task<bool> Delete(Game entity)
	{
		throw new NotImplementedException();
	}

	public async Task<IQueryable<Game>> GetAll()
	{
		throw new NotImplementedException();
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