using Application.Interfaces;
using GameStoreServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class GameController : ControllerBase
	{
		private readonly IGameService _gameService;

		public GameController(IGameService gameService)
		{
			_gameService = gameService;
		}

	}
}
