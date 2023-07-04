using Stgen.Domain.Enums;
using Stgen.Domain.Repository;

namespace Stgen.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal Freight { get; set; }
        public PurchaseStatus Status { get; set; }

        public async Task AddAnimal(IUnitOfWork unitOfWork, Animal animal)
        {
            var animals = await unitOfWork.Purchases.GetAnimals(Id);
            var animalAlreadyInCart = animals.Any(a => a.AnimalId == animal.AnimalId);
            if (animalAlreadyInCart) throw new Exception("Animal already in cart");
            var count = animals.Count();
            // FIXME: I implemented this as it is in the document, but I would suggest to change this first business rule,
            // as it can lead to unwanted behaviour if user is allowed to remove from cart.
            var animalDiscount = count >= 50 ? 0.05m : 0m;
            Discount = count >= 199 ? 0.03m : 0m;
            Freight = count >= 299 ? 0m : 1000m;

            var item = new AnimalPurchase
            {
                AnimalId = animal.AnimalId,
                PurchaseId = Id,
                Discount = animalDiscount,
                Price = animal.Price,
            };
            var animalList = animals.ToList();
            animalList.Add(item);
            await unitOfWork.Purchases.AddAnimal(item);

            var animalCostTotal = animalList.Sum(a => a.Price * (1 - a.Discount));
            var animalCostDiscounted = animalCostTotal * (1 - Discount);
            Total = animalCostDiscounted + Freight;

            await unitOfWork.Purchases.Update(this);
        }
    }
}
