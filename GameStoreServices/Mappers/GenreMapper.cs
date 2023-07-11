using Domain.Entities;

namespace GameStoreServices.Mappers;

public static class GenreMapper
{
	public static Genre ToEntity(this GenreViewModel genre)
	{
		return new Genre
		{
			Name = genre.Name
		};
	}

	public static GenreViewModel ToViewModel(this Genre genre)
	{
		return new GenreViewModel
		{
			Name = genre.Name
		};
	}
}