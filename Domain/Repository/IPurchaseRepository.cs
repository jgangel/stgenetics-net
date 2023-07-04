using Stgen.Domain.Entities;

namespace Stgen.Domain.Repository;

public interface IPurchaseRepository
{
    Task<Purchase?> GetActive(int userId);
    Task<int> CountAnimals(int id);
    Task<IEnumerable<AnimalPurchase>> GetAnimals(int id);
    Task<int> AddAnimal(AnimalPurchase animal);
    Task<int> Create(Purchase purchase);
    Task<int> Update(Purchase purchase);
}