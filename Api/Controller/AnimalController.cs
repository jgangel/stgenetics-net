using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stgen.Api.Auth;
using Stgen.Application.Command;
using Stgen.Domain.Dto;
using Stgen.Domain.Entities;
using Stgen.Domain.Repository;

namespace Stgen.Api.Controller
{
    [Route("animal")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AnimalController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderAnimalHandler _orderHandler;
        public AnimalController(IUnitOfWork unitOfWork, ILogger<AnimalController> logger, IOrderAnimalHandler orderHandler)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _orderHandler = orderHandler;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(Animal animal)
        {
            return await HandleHttpCode(() => _unitOfWork.Animals.Add(animal));
        }

        [HttpPut]
        public async Task<ActionResult<int>> Update(Animal animal)
        {
            return await HandleHttpCode(() => _unitOfWork.Animals.Update(animal));
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await HandleHttpCode(() => _unitOfWork.Animals.Delete(id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> Filter([FromQuery] AnimalFilter animal)
        {
            return await HandleHttpCode(() => _unitOfWork.Animals.Filter(animal));
        }

        [HttpPost]
        [Route("order")]
        public async Task<ActionResult<OrderAnimalResult>> Order(int animalId)
        {
            var order = new OrderAnimal { UserId = User.FindFirst(TokenService.ClaimId)!.Value, AnimalId = animalId };
            return await HandleHttpCode(() => _orderHandler.Handle(order));
        }
    }
}
