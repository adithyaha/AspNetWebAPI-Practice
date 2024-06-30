using CarsAPI_InMemoryDatabase.Models;
using CarsAPI_InMemoryDatabase.Repository.Services;

namespace CarsAPI_InMemoryDatabase.Repository
{
    public class CarsRepository : ICarsRepository
    { 
        private List<Car> _carsList = new List<Car>();
        private int _nextId = 1;
        public bool CreateAsync(Car car)
        {
            if (car == null) throw new ArgumentNullException();
            if (_carsList.Any(c => c.CarId == car.CarId))
            {
                return false;
            }
            car.CarId = _nextId++;
            _carsList.Add(car);
            return true;
           
        }

        public  bool CreateMultiple(IEnumerable<Car> cars)
        {
            if (cars.Count() == 0) throw new ArgumentException("There are no cars to add.");
            foreach (var newCar in cars)
            {
                if (_carsList.Any(e => e.Equals(newCar)))
                {
                    return false;
                }
                newCar.CarId = _nextId++;
                _carsList.Add(newCar);

            }
            return true;
        }

        public  bool DeleteAll()  
        {
            if (_carsList.Count == 0)
            {
                return false;
            }
            _carsList.Clear();
             return true;
            
        }

        public  bool DeleteById(int id)
        {
            var car = _carsList.FirstOrDefault(c => c.CarId == id);
            if (car == null)
            {
                throw new ArgumentException("Car not found.");
            }
           
            
            _carsList.Remove((Car)car);
            return true;
            
        }

        public  bool DeleteByName(string name)
        {
            var car = _carsList.FirstOrDefault(c => c.CarName == name);
            if (car == null)
            {
                throw new ArgumentException("Car not found.");
            }
            
            
            _carsList.Remove((Car)car);
            return false;
           }

        

        public IEnumerable<Car> GetAllAsync()
        {
            return _carsList;
        }

        public Car GetCarById(int id)
        {
            
            var car = _carsList.FirstOrDefault(c => c.CarId == id);
            if (car == null || _carsList.Count == 0) throw new Exception("car not found");
            else return car;
        }

        public Car GetCarByName(string name)
        {
            
            var car = _carsList.FirstOrDefault(c => c.CarName == name);
            if (car == null) throw new Exception("Car not found");
            else return car;
        }

        public bool UpdateById(int id, Car car)
        {
            Car oldCar = _carsList.FirstOrDefault(c => c.CarId == id);
            if (oldCar != null && car != null)
            {
                car.CarId = oldCar.CarId;
                _carsList[_carsList.IndexOf(oldCar)] = car;
                return true;
            }
            return false;

        }

        public bool UpdateByName(string name, Car car)
        {
            Car oldCar = _carsList.FirstOrDefault(c => c.CarName == name);
            if (car != null && oldCar != null)
            {
                car.CarId = oldCar.CarId;
                _carsList[_carsList.IndexOf(oldCar)] = car;
                return true;
            }
            return false;
        }
         
    }
}
