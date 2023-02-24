using Microsoft.AspNetCore.Mvc;
using Friday.Repository.Models;
using Friday.Repository.Repositories;

namespace Friday.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository repository;

        public CarsController(ICarRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await repository.GetCars();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            return await repository.GetCar(id);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> AddCar(Car car)
        {
            var c = await repository.AddCar(car);
            return c;
        }

        [HttpPut]
        public async Task<ActionResult<Car>> UpdateCar(Car car)
        {
            var c = await repository.UpdateCar(car);

            return c;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var str = await repository.DeleteCar(id);
            return Ok(str);
        }
    }
}
