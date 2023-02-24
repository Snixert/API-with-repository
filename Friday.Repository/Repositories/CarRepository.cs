using Friday.Repository.Data;
using Friday.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Friday.Repository.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DatabaseContext context;
        public CarRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<List<Car>> GetCars()
        {
            return await context.Cars.ToListAsync();
        }

        public async Task<Car> GetCar(int id)
        {
            var car = await context.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (car is null)
            {
                return null;
            }
            return car;
        }

        public async Task<Car> AddCar(Car car)
        {
            context.Cars.Add(car);
            await context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> UpdateCar(Car car)
        {
            var c = await context.Cars.FirstOrDefaultAsync(x => x.Id == car.Id);
            
            if (c is null)
            {
                return null;
            }
            c.Brand = car.Brand;
            context.Entry(c).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return c;
        }

        public async Task<string> DeleteCar(int id)
        {
            var car = await context.Cars.FindAsync(id);
            if (car is null)
            {
                return $"Unable to find car with id = {id}";
            }

            context.Cars.Remove(car);
            await context.SaveChangesAsync();
            return $"Deleted car with id = {id}";
        }
    }
}
