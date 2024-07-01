using CarsAPI_EFSQLServer.Data;
using CarsAPI_EFSQLServer.Models;
using CarsAPI_EFSQLServer.Repository.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAPI_EFSQLServer.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _context;

        public CarRepository(CarDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCar(Car car)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car));

            if (await _context.Cars.AnyAsync(c => c.CarId == car.CarId))
                return false;

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddMultipleCars(IEnumerable<Car> cars)
        {
            if (cars == null)
                throw new ArgumentNullException(nameof(cars));

            try
            {
                _context.Cars.AddRange(cars);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAllCars()
        {
            try
            {
                _context.Cars.RemoveRange(_context.Cars);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCarById(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.CarId == id);
            if (car == null)
                return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCarByName(string carName)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.CarName == carName);
            if (car == null)
                return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarById(int carId)
        {
            return await _context.Cars.FirstOrDefaultAsync(car => car.CarId == carId);
        }

        public async Task<Car> GetCarByName(string carName)
        {
            var cars = await _context.Cars.ToListAsync(); // Retrieve all cars to client-side

            return cars.FirstOrDefault(c => string.Equals(c.CarName, carName, StringComparison.OrdinalIgnoreCase));
        }


        public async Task<bool> UpdateCarById(int id, Car car)
        {
            var oldCar = await _context.Cars.FirstOrDefaultAsync(c => c.CarId == id);
            if (oldCar == null)
                return false;

            oldCar.CarName = car.CarName;
            oldCar.Category = car.Category;
            oldCar.CarPrice = car.CarPrice;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCarByName(string name, Car car)
        {
            var oldCar = await _context.Cars.FirstOrDefaultAsync(c => c.CarName == name);
            if (oldCar == null)
                return false;

            oldCar.CarName = car.CarName;
            oldCar.Category = car.Category;
            oldCar.CarPrice = car.CarPrice;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
