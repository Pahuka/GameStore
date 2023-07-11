using Application.Implementations;
using Domain.Entities;

namespace GameStoreServices.Mappers;

public static class GameMapper
{
	public static Game ToEntity(this GameViewModel gameViewModel)
	{
		return new Game
		{
			Id = gameViewModel.Id != Guid.Empty ? gameViewModel.Id : Guid.NewGuid(),
			Name = gameViewModel.Name,
			DevStudio = gameViewModel.DevStudio,
			Genres = gameViewModel.Genres
				.Select(x => new Genre { Name = x.Name })
				.ToList()
		};
	}

	public static GameViewModel ToViewModel(this Game game)
	{
		return new GameViewModel
		{
			Id = game.Id,
			Name = game.Name,
			DevStudio = game.DevStudio,
			Genres = game.Genres
				.Select(x => new GenreViewModel { Name = x.Name })
				.ToList()
		};
	}
}