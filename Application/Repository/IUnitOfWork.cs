namespace Stgen.Application.Repository;

public interface IUnitOfWork
{
    IAnimalRepository Animals { get; }
}