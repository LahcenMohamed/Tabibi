using Microsoft.Extensions.DependencyInjection;
using Reygency.Infrastructure.Features.Authenifactions;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Infrastructure.Email;
using Tabibi.Infrastructure.Features.CurrentUser;
using Tabibi.Infrastructure.Features.Users;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure;

public static class MaduleInfrastructureDependacies
{
    public static IServiceCollection AddInfrastructureDependacies(this IServiceCollection services)
    {
        #region repositories dependacies
        services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        #endregion

        #region services dependacies
        services.AddTransient<IUserServices, UserServices>();
        services.AddTransient<IAuthenficationsServices, AuthenficationsServices>();
        services.AddTransient<ICurrentUserService, CurrentUserService>();
        services.AddTransient<IEmailServices, EmailServices>();
        #endregion
        return services;
    }
}
