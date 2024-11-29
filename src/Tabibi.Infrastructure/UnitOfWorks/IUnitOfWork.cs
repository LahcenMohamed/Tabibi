namespace Reygency.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}
