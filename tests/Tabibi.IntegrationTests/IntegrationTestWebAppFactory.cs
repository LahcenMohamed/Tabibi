using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tabibi.Infrastructure.DbContexts;
using Testcontainers.MsSql;

namespace Tabibi.IntegrationTests
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _container = new MsSqlBuilder()
                    .WithName($"sql-{Guid.NewGuid()}")
                    .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                    .WithPassword("Strong_Password123!")
                    .WithPortBinding(1433, true)
                    .WithEnvironment("ACCEPT_EULA", "Y")
                    .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(context =>
            {
                var descriptor = context.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<TabibiDbContext>));
                if (descriptor is not null)
                {
                    context.Remove(descriptor);
                }
                context.AddDbContext<TabibiDbContext>(op =>
                {
                    op.UseSqlServer(_container.GetConnectionString());
                });
            });
        }

        public Task InitializeAsync()
        {
            return _container.StartAsync();
        }

        Task IAsyncLifetime.DisposeAsync()
        {
            return _container.StopAsync();
        }
    }
}
