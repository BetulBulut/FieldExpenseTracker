using System.Linq.Expressions;
using FieldExpenseTracker.Core.Models;


namespace FieldExpenseTracker.Business.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : BaseModel
{
    Task SaveChangesAsync();
    Task<TEntity> GetByIdAsync(long id, params string[] includes);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes);
    Task<TEntity> GetByParameterAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes);
    Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate, params string[] includes);
    Task<TEntity> AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task DeleteByIdAsync(long id);
}