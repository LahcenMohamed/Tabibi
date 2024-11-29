using Microsoft.AspNetCore.Identity;
using Reygency.Infrastructure.Seeder;
using Scalar.AspNetCore;
using Tabibi.Core;
using Tabibi.Core.Middlewares;
using Tabibi.Domain.Users;
using Tabibi.Infrastructure;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi}
builder.Services.AddOpenApi();
builder.Services.AddRegisrationServices(builder.Configuration)
                .AddInfrastructureDependacies()
                .AddCoreDependacies();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
    var context = scope.ServiceProvider.GetRequiredService<TabibiDbContext>();
    //await MaigrateDataBase.SeedAsync(context);
    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
