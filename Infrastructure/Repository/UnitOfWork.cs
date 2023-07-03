using Stgen.Application.Repository;

namespace Stgen.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IAnimalRepository animals)
    {
        Animals = animals;
    }

    public IAnimalRepository Animals { get; }
}