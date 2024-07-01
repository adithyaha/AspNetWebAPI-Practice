using CarsAPI_EFSQLServer.Models;

namespace CarsAPI_EFSQLServer.Repository.Service
{
    public interface ICarRepository
    {
        // CRUD OPERATIONS ->
        // CREATE

        public Task<bool> AddCar(Car car);
        public Task<bool> AddMultipleCars(IEnumerable<Car> cars);

        // RETRIEVE
        public Task<IEnumerable<Car>> GetAllCars();
        public Task<Car> GetCarById(int carId);
        public Task<Car> GetCarByName(string carName);


        // UPDATE
        public Task<bool> UpdateCarById(int id, Car car);
        public Task<bool> UpdateCarByName(string carName, Car car);


        // DELETE
        public Task<bool> DeleteCarById(int id);
        public Task<bool> DeleteCarByName(string carName);
        public Task<bool> DeleteAllCars();
    }
}
