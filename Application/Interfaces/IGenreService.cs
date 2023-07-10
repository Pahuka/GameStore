namespace Application.Interfaces;

public interface IGenreService : IService<IGenreViewModel>
{
	Task<bool> DeleteById(Guid id, CancellationToken cancellationToken);
	Task<bool> DeleteByName(string name, CancellationToken cancellationToken);
}