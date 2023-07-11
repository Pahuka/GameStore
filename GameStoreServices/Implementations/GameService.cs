using Application.Implementations;
using Application.Interfaces;
using Application.Response;
using Domain.Enums;
using GameStoreServices.Mappers;

namespace GameStoreServices.Implementations;

public class GameService : IGameService
{
	private readonly IGameRepository _gameRepository;

	public GameService(IGameRepository gameRepository)
	{
		_gameRepository = gameRepository;
	}

	public async Task<IResponse<IQueryable<GameViewModel>>> GetAll()
	{
		var response = new Responce<IQueryable<GameViewModel>>();

		try
		{
			var games = await _gameRepository.GetAll();
			response.Data = games.Select(x => x.ToViewModel());
			response.StatusCode = StatusCode.OK;

			return response;
		}
		catch (Exception e)
		{
			response = new Responce<IQueryable<GameViewModel>>();
			response.StatusCode = StatusCode.InternalServerError;
			response.Description = e.Message;

			return response;
		}
	}

	public async Task<IResponse<bool>> Create(GameViewModel viewModel)
	{
		var response = new Responce<bool>();

		try
		{
			response.Data = _gameRepository.Create(viewModel.ToEntity()).IsCompletedSuccessfully;
			response.StatusCode = StatusCode.OK;

			return response;
		}
		catch (Exception e)
		{
			response = new Responce<bool>();
			response.Data = false;
			response.StatusCode = StatusCode.InternalServerError;
			response.Description = e.Message;

			return response;
		}
	}

	public async Task<IResponse<GameViewModel>> Update(GameViewModel viewModel)
	{
		var response = new Responce<GameViewModel>();

		try
		{
			await _gameRepository.Update(viewModel.ToEntity());
			response.Data = viewModel;
			response.StatusCode = StatusCode.OK;

			return response;
		}
		catch (Exception e)
		{
			response = new Responce<GameViewModel>();
			response.StatusCode = StatusCode.InternalServerError;
			response.Description = e.Message;

			return response;
		}
	}

	public async Task<IResponse<bool>> DeleteById(Guid id)
	{
		var response = new Responce<bool>();

		try
		{
			var game = await _gameRepository.GetById(id);

			response.Data = await _gameRepository.Delete(game);
			response.StatusCode = StatusCode.OK;

			return response;
		}
		catch (Exception e)
		{
			response = new Responce<bool>();
			response.StatusCode = StatusCode.InternalServerError;
			response.Description = e.Message;

			return response;
		}
	}

	public async Task<IResponse<IEnumerable<GameViewModel>>> GetByName(string name)
	{
		var response = new Responce<IEnumerable<GameViewModel>>();

		try
		{
			var games = await _gameRepository.GetByName(name);

			if (games == null)
			{
				response.StatusCode = StatusCode.NotFound;

				return response;
			}

			response.Data = games.Select(x=> x.ToViewModel()).ToList();
			response.StatusCode = StatusCode.OK;

			return response;
		}
		catch (Exception e)
		{
			response = new Responce<IEnumerable<GameViewModel>>();
			response.StatusCode = StatusCode.InternalServerError;
			response.Description = e.Message;

			return response;
		}
	}
}