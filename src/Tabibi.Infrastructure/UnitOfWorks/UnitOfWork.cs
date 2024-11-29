using Tabibi.Infrastructure.DbContexts;

namespace Reygency.Infrastructure.UnitOfWorks
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TabibiDbContext _context;
        public UnitOfWork(TabibiDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
