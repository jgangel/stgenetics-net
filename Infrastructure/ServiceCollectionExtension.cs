using Stgen.Application.Repository;
using Stgen.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Stgen.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
