namespace Tabibi.Infrastructure.Shared.Repositories;

public interface IBaseRepository<TModel>
{
    TModel? GetById(Guid id);
    IQueryable<TModel> GetTableNoTracking();
    Task<List<TModel>> GetTableAsTracking();
    TModel Add(TModel entity);
    void AddRange(ICollection<TModel> entities);
    void Update(TModel entity);
    void UpdateRange(ICollection<TModel> entities);
    void Delete(TModel entity);
}
