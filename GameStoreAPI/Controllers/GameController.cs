using Application.Interfaces;
using GameStoreServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
	private readonly IGameService _gameService;

	public GameController(IGameService gameService)
	{
		_gameService = gameService;
	}

	[HttpPost("create")]
	public async Task<ActionResult<bool>> Create([FromBody] GameViewModel gameViewModel)
	{
		var game = await _gameService.Create(gameViewModel);
		return Ok();
	}

	[HttpGet]
	public async Task<ActionResult<GameViewModel>> GetAll()
	{
		var game = await _gameService.GetAll();
		return Ok(game.Data);
	}
}