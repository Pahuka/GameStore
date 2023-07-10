using Application.Interfaces;

namespace GameStoreServices.ViewModels;

public class GenreViewModel : IGenreViewModel
{
	public string Name { get; set; }
	public IList<GameViewModel> Games { get; set; } = new List<GameViewModel>();
}