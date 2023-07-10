using Application.Interfaces;
using Application.Response;
using Domain.Enums;
using GameStoreServices.Mappers;
using GameStoreServices.ViewModels;

namespace GameStoreServices.Implementations;

public class GenreService : IGenreService
{
	private readonly IGenreRepository _genreRepository;

	public GenreService(IGenreRepository genreRepository)
	{
		_genreRepository = genreRepository;
	}

	public async Task<IResponse<IQueryable<IGenreViewModel>>> GetAll()
	{
		var response = new Responce<IQueryable<IGenreViewModel>>();

		try
		{
			var genres = await _genreRepository.GetAll();
			response.Data = genres.Select(x => x.ToViewModel());
			response.StatusCode = StatusCode.OK;

			return response;
		}
		catch (Exception e)
		{
			response = new Responce<IQueryable<IGenreViewModel>>();
			response.StatusCode = StatusCode.InternalServerError;
			response.Description = e.Message;

			return response;
		}
	}

	public async Task<IResponse<bool>> Create(IGenreViewModel viewModel)
	{
		var response = new Responce<bool>();

		try
		{
			response.Data = _genreRepository.Create((viewModel as GenreViewModel).ToEntity()).IsCompletedSuccessfully;
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

	public async Task<IResponse<IGenreViewModel>> Update(IGenreViewModel viewModel)
	{
		var response = new Responce<IGenreViewModel>();

		try
		{
			await _genreRepository.Update((viewModel as GenreViewModel).ToEntity());
			response.Data = viewModel;
			response.StatusCode = StatusCode.OK;

			return response;
		}
		catch (Exception e)
		{
			response = new Responce<IGenreViewModel>();
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
			var genre = await _genreRepository.GetById(id);

			response.Data = await _genreRepository.Delete(genre);
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
			var genre = await _genreRepository.GetByName(name);
			response.Data = await _genreRepository.Delete(genre);
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