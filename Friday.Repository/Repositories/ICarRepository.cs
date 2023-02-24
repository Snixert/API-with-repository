using Friday.Repository.Models;

namespace Friday.Repository.Repositories
{
    public interface ICarRepository
    {
        Task<Car> GetCar(int id);
        Task<List<Car>> GetCars();
        Task<Car> AddCar(Car car);
        Task<Car> UpdateCar(Car car);
        Task<string> DeleteCar(int id);
    }
}
