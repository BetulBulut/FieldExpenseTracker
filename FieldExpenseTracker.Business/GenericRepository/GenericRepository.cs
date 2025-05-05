using System.Linq.Expressions;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.Enums;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;


namespace FieldExpenseTracker.Business.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel
{
    private readonly AppDbContext context;

    public GenericRepository(AppDbContext context)
    {
        this.context = context;
    }


    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task DeleteByIdAsync(long id)
    {
        var entity = await context.Set<TEntity>().FindAsync(id);
        if (entity != null)
        {
            context.Set<TEntity>().Remove(entity);
        }
    }

    public void Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }

    public async Task<List<TEntity>> GetAllAsync(params string[] includes)
    {
        var query = context.Set<TEntity>().AsQueryable();
        query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
        return await EntityFrameworkQueryableExtensions.ToListAsync(query);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes)
    {
        var query = context.Set<TEntity>().Where(predicate).AsQueryable();
        query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
        return await EntityFrameworkQueryableExtensions.ToListAsync(query);
    }

    public async Task<TEntity> GetByIdAsync(long id, params string[] includes)
    {
        var query = context.Set<TEntity>().AsQueryable();
        query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
        return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(query, x => x.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public void Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
    }

    public async Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate, params string[] includes)
    {
        var query = context.Set<TEntity>().Where(predicate).AsQueryable();
        query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
        return await EntityFrameworkQueryableExtensions.ToListAsync(query);
    }

    public Task<TEntity> GetByParameterAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes)
    {
        var query = context.Set<TEntity>().AsQueryable();
        query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
        return EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(query, predicate);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await context.Set<TEntity>().AnyAsync(predicate);
    }
     public async Task<List<string>> GetAdminEmailsAsync()
    {
        return await context.Set<User>()
            .Where(u => u.IsActive)
            .Where(u => u.Role == RoleEnum.Admin)
            .Select(u => u.Email)
            .ToListAsync();
    }
}