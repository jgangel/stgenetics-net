namespace Stgen.Domain.Entities
{
    public class AnimalPurchase
    {
        public int AnimalId { get; set; }
        public int PurchaseId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
