namespace Application.Interfaces;

public interface IRepository<TEntity>
{
	Task<bool> Create(TEntity entity);
	Task<TEntity> Update(TEntity entity);
	Task<bool> Delete(TEntity entity);
	Task<IQueryable<TEntity>> GetAll();
}