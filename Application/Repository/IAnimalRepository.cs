using Stgen.Application.Query;
using Stgen.Domain.Entities;

namespace Stgen.Application.Repository;

public interface IAnimalRepository: IRepository<Animal>
{
    Task<IEnumerable<Animal>> Filter(AnimalFilter filter);
}