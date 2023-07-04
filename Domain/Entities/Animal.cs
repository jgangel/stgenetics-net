using Stgen.Domain.Enums;

namespace Stgen.Domain.Entities
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public required string Name { get; set; }
        public required string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
    }
}
