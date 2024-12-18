using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tabibi.Infrastructure.DbContexts;

namespace Tabibi.Infrastructure.Shared.Repositories;

public class BaseRepository<TModel>(TabibiDbContext context, IConfiguration configuration) : IBaseRepository<TModel> where TModel : class
{
    #region Vars / Props

    protected readonly TabibiDbContext _dbContext = context;
    protected readonly string _connectionString = configuration.GetConnectionString("DefaultConnectionString");


    #endregion

    #region Methods

    #endregion

    #region Actions
    public virtual TModel? GetById(Guid id)
    {
        return _dbContext.Set<TModel>().Find(id);
    }


    public virtual IQueryable<TModel> GetTableNoTracking()
    {
        return _dbContext.Set<TModel>().AsNoTracking().AsQueryable();
    }


    public virtual void AddRange(ICollection<TModel> entities)
    {
        _dbContext.Set<TModel>().AddRange(entities);

    }
    public virtual TModel Add(TModel entity)
    {
        _dbContext.Set<TModel>().Add(entity);

        return entity;
    }

    public virtual void Update(TModel entity)
    {
        _dbContext.Set<TModel>().Update(entity);

    }

    public virtual void Delete(TModel entity)
    {
        _dbContext.Set<TModel>().Remove(entity);
    }
    public virtual void DeleteRange(ICollection<TModel> entities)
    {
        _dbContext.Set<TModel>().RemoveRange(entities);
    }

    public async Task<List<TModel>> GetTableAsTracking()
    {
        return await _dbContext.Set<TModel>().ToListAsync();

    }

    public virtual void UpdateRange(ICollection<TModel> entities)
    {
        _dbContext.Set<TModel>().UpdateRange(entities);
    }
    #endregion
}
