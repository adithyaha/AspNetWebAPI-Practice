using CarsAPI_EFSQLServer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarsAPI_EFSQLServer.Models;
using CarsAPI_EFSQLServer.Repository.Service;

namespace CarsAPI_EFSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        // CREATE
        [HttpPost]
        public async Task<ActionResult<bool>> AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            await _carRepository.AddCar(car);
            return Ok(true);
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<bool>> AddMultiple(IEnumerable<Car> cars)
        {
            if (cars.Any(c => c == null))
            {
                throw new ArgumentNullException("There was an error in adding atleast one of the cars.");
            }
            foreach (var car in cars)
            {
                await _carRepository.AddCar(car);
            }
            return Ok(true);
        }



        // RETRIEVE
        [HttpGet]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
        {
            var cars = await _carRepository.GetAllCars();
            return Ok(cars);

        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var car = await _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Car>> GetCarByName(string name)
        {
            var car = await _carRepository.GetCarByName(name);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }



        // UPDATE
        [HttpPut("id/{id}")]
        public async Task<ActionResult<bool>> UpdateCarById(int id, Car car)
        {
            var oldCar = await _carRepository.GetCarById(id);
            if (oldCar == null)
            {
                return BadRequest();
            }
            await _carRepository.UpdateCarById(id, car);
            return Ok(true);
        }

        [HttpPut("name/{name}")]
        public async Task<ActionResult<bool>> UpdateCarByName(string name, Car car)
        {
            var oldCar = await _carRepository.GetCarByName(name);
            if (oldCar == null)
            {
                return BadRequest();
            }
            await _carRepository.UpdateCarByName(name, car);
            return Ok(true);
        }



        // DELETE

        [HttpDelete("all")]
        public async Task<ActionResult<bool>> DeleteAllCars()
        {
            await _carRepository.DeleteAllCars();
            return Ok(true);
        }

        [HttpDelete("id/{carId}")]
        public async Task<ActionResult<bool>> DeleteCarById(int carId)
        {
            await _carRepository.DeleteCarById(carId);
            return Ok(true);
        }

        [HttpDelete("name/{carName}")]
        public async Task<ActionResult<bool>> DeleteCarByName(string carName)
        {
            await _carRepository.DeleteCarByName(carName);
            return Ok(true);
        }

    }
}
