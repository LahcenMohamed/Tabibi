namespace Tabibi.Infrastructure.Shared.Repositories;

public interface IBaseRepository<TModel>
{
    TModel? GetById(Guid id);
    IQueryable<TModel> GetAll();
    TModel Add(TModel entity);
    void AddRange(ICollection<TModel> entities);
    void Update(TModel entity);
    void UpdateRange(ICollection<TModel> entities);
    void Delete(TModel entity);
}
