using Domain.Entities;

namespace Application.Interfaces;

public interface IRepository<TEntity> where TEntity : EntityBase
{
    Task<TEntity> GetById(Guid id);

    Task<IEnumerable<TEntity>> GetAll();

    Task<TEntity> Insert(TEntity entity);

    Task<TEntity> Update(TEntity entity);

    Task Delete(Guid id);
}