using System.Collections.Generic;
using ISA.Model;
using ISA.DataAccessLayer;

namespace ISA.BusinessLogic
{
    /// <summary>
    /// Сервис, отвечающий исключительно за аналитические бизнес-функции.
    /// </summary>
    public class CarAnalytics : ICarAnalytics
    {
        private readonly IRepository<Car> _carRepository;

        public CarAnalytics(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }


        /// <summary>
        /// Бизнес-функция для группировки всех существующих автомобилей по их маркам (брендам).
        /// </summary>
        /// <returns>Словарь, где ключом является марка автомобиля, а значением — список автомобилей этой марки.</returns>
        public Dictionary<Car.CarBrand, List<Car>> GroupByBrand()
        {
            var allCars = _carRepository.GetAll();
            var result = new Dictionary<Car.CarBrand, List<Car>>();
            foreach (var car in allCars)
            {
                if (!result.ContainsKey(car.Brand)) result[car.Brand] = new List<Car>();
                result[car.Brand].Add(car);
            }
            return result;
        }

        /// <summary>
        /// Бизнес-функция фильтрации для поиска автомобилей, стоимость которых не превышает заданный бюджет покупателя.
        /// </summary>
        /// <param name="maxBudget">Максимальная сумма денег (бюджет), которую готов потратить покупатель.</param>
        /// <returns>Список, содержащий автомобили, подходящие под указанный ценовой лимит.</returns>
        public List<Car> GetCarByBudget(decimal maxBudget)
        {
            var allCars = _carRepository.GetAll();
            var result = new List<Car>();
            foreach (var car in allCars)
            {
                if (car.Price <= maxBudget) result.Add(car);
            }
            return result;
        }
    }
}