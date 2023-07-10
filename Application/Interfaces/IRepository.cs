namespace Application.Interfaces;

public interface IRepository<TEntity>
{
	public Task<bool> Create(TEntity entity);
	public Task<TEntity> Update(TEntity entity);
	public Task<bool> Delete(TEntity entity);
	public Task<IQueryable<TEntity>> GetAll();
}