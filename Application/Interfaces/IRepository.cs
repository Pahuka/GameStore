namespace Application.Interfaces;

public interface IRepository<TEntity>
{
	Task<bool> Create(TEntity entity, CancellationToken cancellationToken);
	Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);
	Task<bool> Delete(TEntity entity, CancellationToken cancellationToken);
	Task<IQueryable<TEntity>> GetAll();
}