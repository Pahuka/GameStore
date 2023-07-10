using Application.Interfaces;
using Application.Response;
using Domain.Enums;
using GameStoreServices.Mappers;
using GameStoreServices.ViewModels;

namespace GameStoreServices.Implementations;

public class GameService : IGameService
{
	private readonly IGameRepository _gameRepository;

	public GameService(IGameRepository gameRepository)
	{
		_gameRepository = gameRepository;
	}

	public async Task<IResponse<IQueryable<IGameViewModel>>> GetAll()
	{
		var response = new Responce<IQueryable<IGameViewModel>>();

		try
		{
			var games = await _gameRepository.GetAll();
			response.Data = games.Select(x => x.ToViewModel());
			response.StatusCode = StatusCode.OK;

			return response;
		}
		catch (Exception e)
		{
			response = new Responce<IQueryable<IGameViewModel>>();
			response.StatusCode = StatusCode.InternalServerError;
			response.Description = e.Message;

			return response;
		}
	}

	public async Task<IResponse<bool>> Create(IGameViewModel viewModel)
	{
		var response = new Responce<bool>();

		try
		{
			response.Data = _gameRepository.Create((viewModel as GameViewModel).ToEntity()).IsCompletedSuccessfully;
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

	public async Task<IResponse<IGameViewModel>> Update(IGameViewModel viewModel)
	{
		var response = new Responce<IGameViewModel>();

		try
		{
			await _gameRepository.Update((viewModel as GameViewModel).ToEntity());
			response.Data = viewModel;
			response.StatusCode = StatusCode.OK;

			return response;
		}
		catch (Exception e)
		{
			response = new Responce<IGameViewModel>();
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

	public async Task<IResponse<bool>> DeleteByName(string name)
	{
		var response = new Responce<bool>();

		try
		{
			var game = await _gameRepository.GetByName(name);
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
}