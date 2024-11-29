using Microsoft.EntityFrameworkCore;
using Tabibi.Infrastructure.DbContexts;

namespace Tabibi.Infrastructure.Seeder
{
    public static class MaigrateDataBase
    {
        public static async Task SeedAsync(TabibiDbContext context)
        {
            await context.Database.MigrateAsync();
        }
    }
}
