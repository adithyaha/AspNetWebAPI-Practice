using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarsAPI_InMemoryDatabase.Repository;
using CarsAPI_InMemoryDatabase.Models;
using CarsAPI_InMemoryDatabase.Repository.Services;

namespace CarsAPI_InMemoryDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsRepository _carsRepository;

        public CarsController(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        // CREATE OPERATIONS !!!

        [HttpPost]
        public ActionResult<Car> AddCar(Car car)
        {
            _carsRepository.CreateAsync(car);
            return Ok(car);
        }

        [HttpPost("multiple")]
        public ActionResult<IEnumerable<Car>> AddMultipleCars(IEnumerable<Car> cars)
        {
            _carsRepository.CreateMultiple(cars);
            return Ok(cars);
        }

        // RETRIEVE OPERATIONS !!!

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            var carsList = _carsRepository.GetAllAsync();
            return Ok(carsList);
        }

        [HttpGet("id/{id}")]
        public ActionResult<Car> GetCarById(int id)
        {
            var car = _carsRepository.GetCarById(id);
            return Ok(car);
        }

        [HttpGet("name/{name}")]
        public ActionResult<Car> GetCarByName(string name)
        {
            name.Replace(' ', '_');
            var car = _carsRepository.GetCarByName(name);
            return Ok(car);
        }

        // UPDATE OPERATIONS !!!

        [HttpPut("updateById/{id}")]
        public ActionResult<Car> UpdateCarById(int id, Car car)
        {
            var updated = _carsRepository.UpdateById(id, car);

            if (!updated)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPut("UpdateByName/{name}")]
        public ActionResult<Car> UpdateCarByName(string name, Car car)
        {
            name.Replace(' ', '_');
            var updated = _carsRepository.UpdateByName(name, car);
            if (!updated)
            {
                return NotFound();
            }
            return Ok(car);
        }

        // DELETE OPERATIONS !!!

        [HttpDelete("all")]
        public ActionResult<bool> DeleteAllCars()
        {
            var success = _carsRepository.DeleteAll();
            return Ok(success);
        }

        [HttpDelete("id/{id}")]
        public ActionResult<bool> DeleteCarsById(int id)
        {
            var success = _carsRepository.DeleteById(id);
            return Ok(success);
        }

        [HttpDelete("name/{name}")]
        public ActionResult<bool> DeleteCarsByName(string name)
        {
            name.Replace(' ', '_');
            var success = _carsRepository.DeleteByName(name);
            return Ok(success);
        }
    }
}
