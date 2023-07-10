using Application.Interfaces;
using Application.Response;

namespace GameStoreServices.Implementations;

public class GenreService : IGenreService
{
	public async Task<IResponse<IQueryable<IGenreViewModel>>> GetAll()
	{
		throw new NotImplementedException();
	}

	public async Task<IResponse<bool>> Create(IGenreViewModel viewModel, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task<IResponse<IGenreViewModel>> Update(IGenreViewModel viewModel, CancellationToken cancellationToken)
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