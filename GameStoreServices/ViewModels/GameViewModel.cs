﻿using Application.Interfaces;

namespace GameStoreServices.ViewModels;

public class GameViewModel : IGameViewModel
{

	public Guid Id { get; set; }
	public string Name { get; set; }
	public string DevStudio { get; set; }
	public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
}