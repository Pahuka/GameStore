using Domain.Entities;

namespace Application.Interfaces;

public interface IGameService : IService<IGameViewModel>
{
	Task<bool> DeleteById (Guid id, CancellationToken cancellationToken);
	Task<bool> DeleteByName (string name, CancellationToken cancellationToken);
}