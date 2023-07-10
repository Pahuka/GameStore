using Application.Response;

namespace Application.Interfaces;

public interface IService<TViewModel>
{
	Task<IResponse<IQueryable<TViewModel>>> GetAll();
	Task<IResponse<bool>> Create(TViewModel viewModel, CancellationToken cancellationToken);
	Task<IResponse<TViewModel>> Update(TViewModel viewModel, CancellationToken cancellationToken);
}