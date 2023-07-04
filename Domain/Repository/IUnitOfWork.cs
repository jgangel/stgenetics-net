namespace Stgen.Domain.Repository;

public interface IUnitOfWork
{
    IAnimalRepository Animals { get; }
    IApplicationUserStore Users { get; }
    IPurchaseRepository Purchases { get; }
}