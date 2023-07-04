using Stgen.Domain.Repository;

namespace Stgen.Application.Command
{
    public class OrderAnimal
    {
        public int AnimalId { get; set; }
        public required string UserId { get; set; }
    }

    public class OrderAnimalResult
    {
        public int AnimalId { get; set; }
        public decimal Total { get; set; }
    }

    public interface IOrderAnimalHandler
    {
        Task<OrderAnimalResult> Handle(OrderAnimal order);
    }


    public class OrderAnimalHandler : IOrderAnimalHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderAnimalHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderAnimalResult> Handle(OrderAnimal order)
        {
            var animal = await _unitOfWork.Animals.GetById(order.AnimalId) ?? throw new Exception("Selected animal does not exist");
            var user = await _unitOfWork.Users.FindByIdAsync(order.UserId, CancellationToken.None) ?? throw new Exception("User not found");
            var cart = await user.GetOrCreateCart(_unitOfWork);
            await cart.AddAnimal(_unitOfWork, animal);
            var result = new OrderAnimalResult
            {
                AnimalId = order.AnimalId,
                Total = cart.Total
            };
            return result;
        }
    }
}
