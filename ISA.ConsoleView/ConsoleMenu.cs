using System;
using System.Collections.Generic;
using ISA.Model;

namespace ISA.ConsoleView
{
    class Program
    {
        private static Logic _logic = new Logic();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Вывести список всех автомобилей");
                Console.WriteLine("2. Добавить новый автомобиль");
                Console.WriteLine("3. Обновить данные автомобиля");
                Console.WriteLine("4. Удалить автомобиль");
                Console.WriteLine("5. Фильтр по бюджету");
                Console.WriteLine("6. Группировать по бюджету покупателя");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите пункт меню: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllCars();
                        break;
                    case "2":
                        AddNewCar();
                        break;
                    case "3":
                        UpdateCarData();
                        break;
                    case "4":
                        DeleteCarData();
                        break;
                    case "5":
                        FilterCarsByBudget();
                        break;
                    case "6":
                        GroupByBrand();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный пункт меню");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Выводит в консоль список всех существующих автомобилей.
        /// </summary>
        private static void ShowAllCars()
        {
            Console.Clear();
            List<Car> cars = _logic.GetCars();

            if (cars.Count == 0)
            {
                Console.WriteLine("Список пуст.");
            }
            else
            {
                foreach (Car car in cars)
                {
                    Console.WriteLine($"ID: {car.Id}  Бренд: {car.Brand}  Цена: {car.Price:C}");
                }
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню...");
            Console.ReadKey();
        }

        /// <summary>
        /// Пошагово запрашивает бренд и цену, затем добавляет машину через бизнес-логику.
        /// </summary>
        private static void AddNewCar()
        {
            Console.Clear();
            Car.CarBrand brand = SelectBrandMenu();
            Console.Write("Введите цену автомобиля: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)
            {
                int newId = _logic.AddCar(brand, price);
                Console.WriteLine($"Успешно добавлено! Автомобилю присвоен ID: {newId}");
            }
            else
            {
                Console.WriteLine("Введено некорректное значение цены.");
            }

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadKey();
        }

        /// <summary>
        /// Запрашивает ID, новый бренд и новую цену для изменения данных машины.
        /// </summary>
        private static void UpdateCarData()
        {
            Console.Clear();
            Console.Write("Введите ID автомобиля, который хотите изменить: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Car car = _logic.GetCarById(id);
                if (car == null)
                {
                    Console.WriteLine("Автомобиль с таким ID не найден.");
                }
                else
                {
                    Console.WriteLine($"Вы редактируете: {car.Brand} Текущая цена: {car.Price:C}");
                    Car.CarBrand newBrand = SelectBrandMenu();

                    Console.Write("Введите новую цену: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newPrice) && newPrice >= 0)
                    {
                        _logic.UpdateCar(id, newBrand, newPrice);
                        Console.WriteLine("Данные автомобиля обновлены");
                    }
                    else
                    {
                        Console.WriteLine("Некорректная цена.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ID.");
            }

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadKey();
        }

        /// <summary>
        /// Запрашивает ID машины и удаляет её из системы.
        /// </summary>
        private static void DeleteCarData()
        {
            Console.Clear();
            Console.Write("Введите ID автомобиля для удаления: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (_logic.DeleteCar(id))
                {
                    Console.WriteLine("Автомобиль удален.");
                }
                else
                {
                    Console.WriteLine("Автомобиль с таким ID не найден.");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ID.");
            }

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadKey();
        }

        /// <summary>
        /// Запрашивает у пользователя максимальную сумму и выводит подходящие машины.
        /// </summary>
        private static void FilterCarsByBudget()
        {
            Console.Clear();
            Console.Write("Введите ваш максимальный бюджет: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal budget) && budget >= 0)
            {
                List<Car> affordableCars = _logic.GetCarByBudget(budget);

                if (affordableCars.Count == 0)
                {
                    Console.WriteLine("Нет автомобилей, подходящих под бюджет.");
                }
                else
                {
                    Console.WriteLine("\nДоступные автомобили:");
                    foreach (Car car in affordableCars)
                    {
                        Console.WriteLine($"ID: {car.Id}  Бренд: {car.Brand}  Цена: {car.Price:C}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный формат бюджета.");
            }

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, осуществляющий группировку списку по автомобилям.
        /// </summary>
        private static void GroupByBrand()
        {
            Console.Clear();
            List<Car> allCars = _logic.GetCars();

            if (allCars.Count == 0)
            {
                Console.WriteLine("Список автомобилей пуст. Группировать нечего.");
            }
            else
            {
                var groupedCars = new Dictionary<Car.CarBrand, List<Car>>();

                foreach (var car in allCars)
                {
                    if (!groupedCars.ContainsKey(car.Brand))
                    {
                        groupedCars[car.Brand] = new List<Car>();
                    }
                    groupedCars[car.Brand].Add(car);
                }

                foreach (var group in groupedCars)
                {
                    Console.WriteLine($"Бренд: {group.Key} (Всего машин: {group.Value.Count})");
                    foreach (var car in group.Value)
                    {
                        Console.WriteLine($" ID: {car.Id} Цена: {car.Price:C}");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню...");
            Console.ReadKey();
        }


        /// <summary>
        /// Вспомогательное текстовое меню для выбора марки машины.
        /// </summary>
        private static Car.CarBrand SelectBrandMenu()
        {
            while (true)
            {
                Console.WriteLine("\nВыберите бренд:");
                Console.WriteLine("1. BMW");
                Console.WriteLine("2. Mercedes");
                Console.WriteLine("3. Volvo");
                Console.WriteLine("4. Audi");
                Console.WriteLine("5. Volkswagen");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": return Car.CarBrand.BMW;
                    case "2": return Car.CarBrand.Mercedes;
                    case "3": return Car.CarBrand.Volvo;
                    case "4": return Car.CarBrand.Audi;
                    case "5": return Car.CarBrand.Volkswagen;
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                        break;
                }
            }
        }
    }
}
