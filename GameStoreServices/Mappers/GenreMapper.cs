using System.Collections.Immutable;
using Domain.Entities;
using GameStoreServices.ViewModels;

namespace GameStoreServices.Mappers;

public static class GenreMapper
{
	public static Genre ToEntity(this GenreViewModel genre)
	{
		return new Genre()
		{
			Name = genre.Name,
			Games = genre.Games
				.Select(x => x.ToEntity())
				.ToList()
		};
	}

	public static GenreViewModel ToViewModel(this Genre genre)
	{
		return new GenreViewModel()
		{
			Name = genre.Name,
			Games = genre.Games
				.Select(x => x.ToViewModel())
				.ToList()
		};
	}
}