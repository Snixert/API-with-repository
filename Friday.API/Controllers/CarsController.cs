using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Friday.Repository.Data;
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
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            var c = await repository.AddCar(car);
            return c;
        }

        [HttpPut()]
        public async Task<ActionResult<Car>> UpdateCar(Car car)
        {
            car = await repository.UpdateCar(car);

            return car;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var str = await repository.DeleteCar(id);
            return Ok(str);
        }
    }
}
