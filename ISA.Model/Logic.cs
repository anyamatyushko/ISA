using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA.Model
{
    public class Logic
    {
        private List<Car> _cars = new List<Car>();

        private int _nextId = 1;

        /// <summary>
        /// Метод для добавления нового автомобиля в систему.
        /// </summary>
        /// <param name="brand">Марка автомобиля.</param>
        /// <param name="price">Стоимость автомобиля.</param>
        /// <returns>Уникальный ID созданного автомобиля.</returns>
        public int AddCar(string brand, decimal price)
        {
            int currentId = _nextId;

            Car newCar = new Car();
            newCar.Id = currentId;
            newCar.Price = price;

            _cars.Add(newCar);
            _nextId++;

            return currentId;
        }

        /// <summary>
        /// Метод для получения автомобиля по его ID.
        /// </summary>
        /// <param name="id">ID автомобиля.</param>
        /// <returns>Автомобиль с запрашиваемым ID, либо null в случае отсутствия такого автомобиля.</returns>
        public Car GetCarById(int id)
        {
            foreach (Car c in _cars)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// Метод для обновления данных об автомобиле.
        /// </summary>
        /// <param name="id"> ID автомобиля.</param>
        /// <param name="newBrand">Марка автомобиля для обновления.</param>
        /// <param name="newPrice">Стоимость автомобиля для обновления.</param>
        /// <returns>Успешное, либо неуспешное подтверждение изменения данных об автомобиле.</returns>
        public bool UpdateCar(int id, string newBrand, decimal newPrice)
        {
            foreach (Car c in _cars)
            {
                if (c.Id == id)
                {
                    c.Brand = newBrand;
                    c.Price = newPrice;

                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Метод для удаления автомобиля.
        /// </summary>
        /// <param name="id">ID автомобиля.</param>
        /// <returns>Успешное, либо неуспешное подтверждение удаления автомобиля.</returns>
        public bool DeleteCar(int id)
        {
            Car carToDelete = GetCarById(id);

            if (carToDelete == null)
            {
                return false;
            }

            _cars.Remove(carToDelete);
            return true;
        }

        /// <summary>
        /// Метод для группировки автомобилей по их марке.
        /// </summary>
        /// <returns>Сгрупированный по марке словарь автомобилей.</returns>
        public Dictionary<string, List<Car>> GroupByBrand() 
        {
            Dictionary<string,List<Car>> result = new Dictionary<string, List<Car>>();

            foreach (Car c in _cars)
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
        /// Метод для выбора автомобилей по платежеспособности покупателя.
        /// </summary>
        /// <param name="maxBudget">Бюджет покупателя.</param>
        /// <returns>Список автомобилей, ктр. в состоянии купить покупатель.</returns>
        public List<Car> GetCarByBudget(decimal maxBudget)
        {
            List<Car> suitableCars = new List<Car>();

            foreach (Car c in _cars)
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
