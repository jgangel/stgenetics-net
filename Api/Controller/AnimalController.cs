using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stgen.Application.Query;
using Stgen.Application.Repository;
using Stgen.Domain.Entities;

namespace Stgen.Api.Controller
{
    [Route("animal")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AnimalController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnimalController(IUnitOfWork unitOfWork, ILogger<AnimalController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
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
    }
}
