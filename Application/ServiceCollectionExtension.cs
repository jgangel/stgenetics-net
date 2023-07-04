using Microsoft.Extensions.DependencyInjection;
using Stgen.Application.Command;

namespace Stgen.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void RegisterHandlers(this IServiceCollection services)
    {
        services.AddTransient<IOrderAnimalHandler, OrderAnimalHandler>();
    }
}
