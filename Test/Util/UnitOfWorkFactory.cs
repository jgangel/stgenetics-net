using Stgen.Application.Repository;
using Stgen.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;

namespace Stgen.Test.Util
{
    internal class UnitOfWorkFactory
    {
        public static IUnitOfWork Create(IConfiguration configuration)
        {
            return new UnitOfWork();
        }
        public static IUnitOfWork CreateMock(IConfiguration configuration)
        {
            return new UnitOfWork();
        }
    }
}
