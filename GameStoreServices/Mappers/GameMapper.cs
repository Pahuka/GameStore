using Domain.Entities;
using GameStoreServices.ViewModels;

namespace GameStoreServices.Mappers;

public static class GameMapper
{
	public static Game ToEntity(this GameViewModel gameViewModel)
	{
		return new Game()
		{
			Name = gameViewModel.Name,
			Genres = gameViewModel.Genres
				.Select(x => x.ToEntity())
				.ToList()
		};
	}

	public static GameViewModel ToViewModel(this Game game)
	{
		return new GameViewModel()
		{
			Name = game.Name,
			DevStudio = game.DevStudio,
			Genres = game.Genres
				.Select(x=> x.ToViewModel())
				.ToList()
		};
	}
}