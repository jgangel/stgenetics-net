using Stgen.Domain.Repository;

namespace Stgen.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IAnimalRepository animals, IApplicationUserStore users, IPurchaseRepository purchases)
    {
        Animals = animals;
        Users = users;
        Purchases = purchases;
    }

    public IAnimalRepository Animals { get; }
    public IApplicationUserStore Users { get; }
    public IPurchaseRepository Purchases { get; }
}