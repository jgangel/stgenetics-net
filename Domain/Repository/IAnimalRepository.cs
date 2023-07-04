using Stgen.Domain.Dto;
using Stgen.Domain.Entities;

namespace Stgen.Domain.Repository;

public interface IAnimalRepository : IRepository<Animal>
{
    Task<IEnumerable<Animal>> Filter(AnimalFilter filter);
}