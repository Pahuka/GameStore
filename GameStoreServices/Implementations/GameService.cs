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
			response.Data = games.Select(x=> x.ToViewModel());
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

	public async Task<IResponse<bool>> Create(IGameViewModel viewModel, CancellationToken cancellationToken)
	{
		var response = new Responce<bool>();
		
		try
		{
			response.Data = _gameRepository.Create((viewModel as GameViewModel).ToEntity(), cancellationToken).IsCompletedSuccessfully;
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

	public async Task<IResponse<IGameViewModel>> Update(IGameViewModel viewModel, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task<bool> DeleteById(Guid id, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task<bool> DeleteByName(string name, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}