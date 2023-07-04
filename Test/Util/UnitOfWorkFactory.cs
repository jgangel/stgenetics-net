using Microsoft.Extensions.Configuration;
using Stgen.Domain.Repository;
using Stgen.Infrastructure.Repository;

namespace Stgen.Test.Util
{
    internal class UnitOfWorkFactory
    {
        public static IUnitOfWork Create(IConfiguration configuration)
        {
            var animals = new AnimalRespository(configuration);
            var users = new ApplicationUserStore(configuration);
            var purchases = new PurchaseRepository(configuration);
            return new UnitOfWork(animals, users, purchases);
        }
    }
}
