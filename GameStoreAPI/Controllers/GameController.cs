using Application.Implementations;
using Application.Interfaces;
using Application.Response;
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
		var response = await _gameService.Create(gameViewModel);

		return CheckResponse(response);
	}

	[HttpPut("update")]
	public async Task<ActionResult<GameViewModel>> Update([FromBody] GameViewModel gameViewModel)
	{
		var response = await _gameService.Update(gameViewModel);

		return CheckResponse(response).Result;
	}

	[HttpDelete("delete/{id}")]
	public async Task<ActionResult<bool>> Delete(Guid id)
	{
		var response = await _gameService.DeleteById(id);

		return CheckResponse(response);
	}

	[HttpGet("getAll")]
	public async Task<ActionResult<GameViewModel>> GetAll()
	{
		var response = await _gameService.GetAll();

		return CheckResponse(response).Result;
	}

	[HttpGet("{name}")]
	public async Task<ActionResult<GameViewModel>> GetByName(string name)
	{
		var response = await _gameService.GetByName(name);

		return CheckResponse(response).Result;
	}

	[HttpGet("jenre")]
	public async Task<ActionResult<GameViewModel>> GetByGenre([FromBody] string[] jenre)
	{
		return CheckResponse(await _gameService.GetByGenres(jenre)).Result;
	}

	private ActionResult<T> CheckResponse<T>(IResponse<T> response)
	{
		if (response.StatusCode == Domain.Enums.StatusCode.OK)
			return Ok(response.Data);

		if (response.StatusCode == Domain.Enums.StatusCode.NotFound)
			return NotFound();

		if (response.StatusCode == Domain.Enums.StatusCode.InternalServerError)
			return Problem(response.Description);

		return NoContent();
	}
}