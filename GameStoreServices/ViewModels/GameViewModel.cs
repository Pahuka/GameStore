using Application.Interfaces;

namespace GameStoreServices.ViewModels;

public class GameViewModel : IGameViewModel
{
	public string Name { get; set; }
	public string DevStudio { get; set; }
	public IList<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
}