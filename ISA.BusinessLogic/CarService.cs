using System;
using System.Collections.Generic;
using ISA.Model;
using ISA.DataAccessLayer;

namespace ISA.BusinessLogic
{
    /// <summary>
    /// Сервис, отвечающий только за базовый учет и валидацию данных автомобилей.
    /// </summary>
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;


        public CarService(IRepository<Car> carRepository)
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
            if (price <= 0) throw new ArgumentException("Стоимость должна быть больше нуля!");
            var car = new Car { Brand = brand, Price = price };
            return _carRepository.Create(car);
        }

        /// <summary>
        /// Универсальный метод для поиска автомобиля в базе данных по его уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный числовой идентификатор (ID) автомобиля.</param>
        /// <returns>Объект автомобиля, если он найден; в противном случае — null.</returns>
        public Car? GetById(int id) => _carRepository.GetById(id);

        /// <summary>
        /// Универсальный метод для извлечения полного списка всех автомобилей, хранящихся в базе данных.
        /// </summary>
        /// <returns>Список, содержащий все автомобили из базы данных.</returns>
        public List<Car> GetAll() => _carRepository.GetAll();

        /// <summary>
        /// Универсальный метод для обновления бренда и стоимости существующего автомобиля по его ID.
        /// </summary>
        /// <param name="id">Уникальный числовой идентификатор (ID) автомобиля, данные которого нужно изменить.</param>
        /// <param name="newBrand">Новая марка автомобиля.</param>
        /// <param name="newPrice">Новая стоимость автомобиля.</param>
        /// <returns>Значение true, если данные автомобиля успешно обновлены; в противном случае — false.</returns>
        public bool Update(int id, Car.CarBrand newBrand, decimal newPrice)
        {
            var car = new Car { Id = id, Brand = newBrand, Price = newPrice };
            return _carRepository.Update(car);
        }

        /// <summary>
        /// Универсальный метод для удаления автомобиля из системы по его уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный числовой идентификатор (ID) автомобиля, который необходимо удалить.</param>
        /// <returns>Значение true, если автомобиль успешно удален; в противном случае — false.</returns>
        public bool Delete(int id) => _carRepository.Delete(id);
    }
}