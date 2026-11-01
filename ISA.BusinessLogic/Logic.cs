using System;
using System.Collections.Generic;
using ISA.Model;

namespace ISA.BusinessLogic
{
    /// <summary>
    /// Реализация единой точки доступа (Фасада) ILogic. 
    /// Класс не содержит собственной бизнес-логики, а делегирует (перенаправляет) все вызовы 
    /// специализированным сервисам учета и аналитики.
    /// </summary>
    public class Logic : ILogic
    {
        private readonly ICarService _carService;
        private readonly ICarAnalytics _carAnalytics;

        /// <summary>
        /// Инициализирует фасадную логику и внедряет необходимые сервисы через DI-контейнер.
        /// </summary>
        /// <param name="carService">Специализированный сервис для CRUD-операций и учета автомобилей.</param>
        /// <param name="carAnalytics">Специализированный сервис для аналитических бизнес-функций.</param>
        public Logic(ICarService carService, ICarAnalytics carAnalytics)
        {
            _carService = carService;
            _carAnalytics = carAnalytics;
        }



        /// <summary>
        /// Перенаправляет запрос на создание нового автомобиля с проверкой в сервис учета.
        /// </summary>
        /// <param name="brand">Марка автомобиля.</param>
        /// <param name="price">Стоимость автомобиля.</param>
        /// <returns>Уникальный числовой идентификатор (ID), сгенерированный для нового автомобиля.</returns>
        public int Create(Car.CarBrand brand, decimal price)
        {
            return _carService.Create(brand, price);
        }

        /// <summary>
        /// Перенаправляет запрос на поиск автомобиля по его уникальному идентификатору в сервис учета.
        /// </summary>
        /// <param name="id">Уникальный числовой идентификатор (ID) автомобиля.</param>
        /// <returns>Объект автомобиля, если он найден; в противном случае — null.</returns>
        public Car? GetById(int id)
        {
            return _carService.GetById(id);
        }

        /// <summary>
        /// Перенаправляет запрос на извлечение полного списка всех автомобилей в сервис учета.
        /// </summary>
        /// <returns>Список, содержащий все автомобили из базы данных.</returns>
        public List<Car> GetAll()
        {
            return _carService.GetAll();
        }

        /// <summary>
        /// Перенаправляет запрос на обновление данных существующего автомобиля в сервис учета.
        /// </summary>
        /// <param name="id">Уникальный числовой идентификатор (ID) автомобиля, данные которого нужно изменить.</param>
        /// <param name="newBrand">Новая марка автомобиля.</param>
        /// <param name="newPrice">Новая стоимость автомобиля.</param>
        /// <returns>Значение true, если данные автомобиля успешно обновлены; в противном случае — false.</returns>
        public bool Update(int id, Car.CarBrand newBrand, decimal newPrice)
        {
            return _carService.Update(id, newBrand, newPrice);
        }

        /// <summary>
        /// Перенаправляет запрос на удаление автомобиля по его уникальному идентификатору в сервис учета.
        /// </summary>
        /// <param name="id">Уникальный числовой идентификатор (ID) автомобиля, который необходимо удалить.</param>
        /// <returns>Значение true, если автомобиль успешно удален; в противном случае — false.</returns>
        public bool Delete(int id)
        {
            return _carService.Delete(id);
        }

        /// <summary>
        /// Перенаправляет запрос на группировку всех автомобилей по их маркам в сервис аналитики.
        /// </summary>
        /// <returns>Словарь, где ключом является марка автомобиля, а значением — список автомобилей этой марки.</returns>
        public Dictionary<Car.CarBrand, List<Car>> GroupByBrand()
        {
            return _carAnalytics.GroupByBrand();
        }

        /// <summary>
        /// Перенаправляет запрос на поиск автомобилей, проходящих по бюджету покупателя, в сервис аналитики.
        /// </summary>
        /// <param name="maxBudget">Максимальная сумма денег (бюджет), которую готов потратить покупатель.</param>
        /// <returns>Список, содержащий автомобили, подходящие под указанный ценовой лимит.</returns>
        public List<Car> GetCarByBudget(decimal maxBudget)
        {
            return _carAnalytics.GetCarByBudget(maxBudget);
        }

    }
}
