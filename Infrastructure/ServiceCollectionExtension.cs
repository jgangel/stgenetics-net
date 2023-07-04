using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Stgen.Application.Repository;
using Stgen.Domain.Entities;
using Stgen.Infrastructure.Repository;

namespace Stgen.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
        services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();

        services.AddTransient<IAnimalRepository, AnimalRespository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
