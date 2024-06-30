using Microsoft.EntityFrameworkCore.InMemory;
using CarsAPI_InMemoryDatabase.Models;
using CarsAPI_InMemoryDatabase.Repository;

namespace CarsAPI_InMemoryDatabase.Repository.Services
{
    public interface ICarsRepository
    {
        //CRUD Operations ->
        

        // CREATE
        public bool CreateAsync (Car car);
        public bool CreateMultiple(IEnumerable<Car> cars);

        // RETRIEVE
        public IEnumerable<Car> GetAllAsync();
        public Car GetCarById(int id);
        public Car GetCarByName(string name);


        // UPDATE
        public bool UpdateById(int id, Car car);
        public bool UpdateByName(string name, Car car);

        // DELETE
        public bool DeleteById(int id);
        public bool DeleteByName(string name);
        public bool DeleteAll();
    }
}
