using Microsoft.Extensions.Configuration;
using Stgen.Application.Repository;
using Stgen.Infrastructure.Repository;

namespace Stgen.Test.Util
{
    internal class UnitOfWorkFactory
    {
        public static IUnitOfWork Create(IConfiguration configuration)
        {
            var animals = new AnimalRespository(configuration);
            return new UnitOfWork(animals);
        }
        public static IUnitOfWork CreateMock(IConfiguration configuration)
        {
            var animals = new AnimalRespository(configuration);
            return new UnitOfWork(animals);
        }
    }
}
