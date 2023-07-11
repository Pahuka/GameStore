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
		var genres = new List<Genre>(entity.Genres);
		var result = new List<Genre>();

		try
		{
			foreach (var genre in genres)
			{
				var currentGenre = await _appDbContext.Genres
					.Include(x => x.Games)
					.FirstOrDefaultAsync(x => x.Name == genre.Name);

				if (currentGenre != null)
				{
					currentGenre.Games.Add(entity);
					//_appDbContext.Genres.Update(currentGenre);
					result.Add(currentGenre);
				}
				else
				{
					genre.Games.Add(entity);
					result.Add(genre);
					//await _appDbContext.Genres.AddAsync(genre);
				}
			}

			entity.Genres = result;
			await _appDbContext.Games.AddAsync(entity);
			return _appDbContext.SaveChangesAsync().IsCompletedSuccessfully;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
		
	}

	public async Task<Game> Update(Game entity)
	{
		var genres = new List<Genre>();
		var oldGame = await _appDbContext.Games
			.Include(x => x.Genres)
			.FirstOrDefaultAsync(x => x.Id == entity.Id);

		if (oldGame == null)
			throw new Exception(); //TODO: Сделать кастомный эксепшн

		foreach (var genre in entity.Genres)
		{
			var oldGenre = oldGame.Genres.FirstOrDefault(x => x.Name == genre.Name);

			if (oldGenre == null)
			{
				var currentGenre = await _appDbContext.Genres
					.Include(x => x.Games)
					.FirstOrDefaultAsync(x => x.Name == genre.Name);

				if (currentGenre != null)
				{
					currentGenre.Games.Add(oldGame);
					genres.Add(currentGenre);
				}
				else
				{
					genre.Games.Add(oldGame);
					genres.Add(genre);
					await _appDbContext.Genres.AddAsync(genre);
				}

				continue;
			}

			genres.Add(oldGenre);
		}

		oldGame.Genres = genres;
		_appDbContext.Games.Update(oldGame);
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
			.Include(x => x.Genres)
			.FirstOrDefaultAsync(x => x.Id == id);
	}

	public async Task<IQueryable<Game>> GetByName(string name)
	{
		return _appDbContext.Games
			.Include(x => x.Genres)
			.Where(x => x.Name == name);
	}
}