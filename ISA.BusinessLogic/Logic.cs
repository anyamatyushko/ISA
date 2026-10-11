using System;
using System.Collections.Generic;
using ISA.Model;
using ISA.DataAccessLayer;

namespace ISA.BusinessLogic
{
    public class Logic
    {
        private readonly IRepository<Car> _carRepository;

        public Logic(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }


        /// <summary>
        /// Универсальный метод для создания (добавления) нового автомобиля в систему с проверкой.
        /// </summary>
        /// <param name="brand">Марка автомобиля.</param>
        /// <param name="price">Стоимость автомобиля.</param>
        /// <returns>Уникальный числовой идентификатор (ID), сгенерированный базой данных для нового автомобиля.</returns>
        public int Create(Car.CarBrand brand, decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Стоимость должна быть больше нуля!");

            Car newCar = new Car
            {
                Brand = brand,
                Price = price
            };

            return _carRepository.Create(newCar);
        }

        /// <summary>
        /// Универсальный метод для поиска автомобиля в базе данных по его уникальному идентификатору.
        /// </summary>
        /// <param name="id">Числовой идентификатор автомобиля, который требуется найти.</param>
        /// <returns>Объект класса Car, если автомобиль найден/null.</returns>
        public Car? GetById(int id)
        {
            return _carRepository.GetById(id);
        }

        /// <summary>
        /// Универсальный метод для обновления бренда и стоимости существующего автомобиля по его ID.
        /// </summary>
        /// <param name="id">Идентификатор изменяемого автомобиля.</param>
        /// <param name="newBrand">Новая марка автомобиля.</param>
        /// <param name="newPrice">Новая стоимость автомобиля.</param>
        /// <returns>Значение true, если автомобиль успешно найден в базе и его данные обновлены/false.</returns>
        public bool Update(int id, Car.CarBrand newBrand, decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Стоимость должна быть больше нуля!");

            Car carToUpdate = _carRepository.GetById(id);
            if (carToUpdate == null) return false;

            carToUpdate.Brand = newBrand;
            carToUpdate.Price = newPrice;

            return _carRepository.Update(carToUpdate);
        }

        /// <summary>
        /// Универсальный метод для удаления автомобиля из системы по его уникальному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор автомобиля, который подлежит удалению.</param>
        /// <returns>Значение true, если автомобиль был найден и успешно удален из базы данных/false.</returns>
        public bool Delete(int id)
        {
            return _carRepository.Delete(id);
        }

        /// <summary>
        /// Универсальный метод для извлечения полного списка всех автомобилей, хранящихся в базе данных.
        /// </summary>
        /// <returns>Список Car, содержащий все существующие в базе данных автомобили.</returns>
        public List<Car> GetAll()
        {
            return _carRepository.GetAll();
        }


        /// <summary>
        /// Бизнес-функция для группировки всех существующих автомобилей по их маркам.
        /// </summary>
        /// <returns>Словарь, где ключом является бренд автомобиля, а значением — список машин, принадлежащих этому бренду.</returns>
        public Dictionary<Car.CarBrand, List<Car>> GroupByBrand()
        {
            Dictionary<Car.CarBrand, List<Car>> result = new Dictionary<Car.CarBrand, List<Car>>();
            List<Car> allCars = _carRepository.GetAll();

            foreach (Car c in allCars)
            {
                if (!result.ContainsKey(c.Brand))
                {
                    result.Add(c.Brand, new List<Car>());
                }
                result[c.Brand].Add(c);
            }
            return result;
        }


        /// <summary>
        /// Бизнес-функция фильтрации для поиска автомобилей, стоимость которых не превышает заданный бюджет покупателя.
        /// </summary>
        /// <param name="maxBudget">Максимальная сумма денег, которую покупатель готов потратить.</param>
        /// <returns>Список Car, содержащий только те автомобили, цена которых меньше или равна указанному бюджету.</returns>
        public List<Car> GetCarByBudget(decimal maxBudget)
        {
            List<Car> suitableCars = new List<Car>();
            List<Car> allCars = _carRepository.GetAll();

            foreach (Car c in allCars)
            {
                if (c.Price <= maxBudget)
                {
                    suitableCars.Add(c);
                }
            }
            return suitableCars;
        }
    }
}


