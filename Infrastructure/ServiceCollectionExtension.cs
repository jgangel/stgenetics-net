using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Stgen.Domain.Entities;
using Stgen.Domain.Repository;
using Stgen.Infrastructure.Repository;

namespace Stgen.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
        services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();

        services.AddTransient<IAnimalRepository, AnimalRespository>();
        services.AddTransient<IApplicationUserStore, ApplicationUserStore>();
        services.AddTransient<IPurchaseRepository, PurchaseRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
