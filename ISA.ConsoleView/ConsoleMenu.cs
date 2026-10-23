using ISA.BusinessLogic;
using ISA.DataAccessLayer;
using ISA.DataAccessLayer.EntityFrameworkCore;
using ISA.Model;
using Microsoft.EntityFrameworkCore;
using Ninject;
using System;
using System.Collections.Generic;


namespace ISA.ConsoleView
{
    class Program
    {
        private static ILogic? _logic;

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppContext.BaseDirectory);

            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string dbPath = System.IO.Path.Combine(userFolder, "MySharedCarDb.mdf");
            string connectionString = $@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=MySharedCarDb;Integrated Security=true;AttachDbFileName={dbPath};";

            // Далее все, что связано с подключением Ninject
            var kernel = new StandardKernel();

            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            kernel.Bind<MyDbContext>().ToSelf().WithConstructorArgument("options", optionsBuilder.Options);
            kernel.Bind<IRepository<Car>>().To<EntityRepository<Car>>().InSingletonScope(); // Репозиторий как синглтон

            // ЕСЛИ НУЖЕН DAPPER: закомментируй две строчки выше и раскомментируй эту:
            // kernel.Bind<IRepository<Car>>().To<DapperRepository>().WithConstructorArgument("connectionString", connectionString).InSingletonScope();

            kernel.Bind<ILogic>().To<Logic>();

            _logic = kernel.Get<ILogic>();


            while (true)
                {
                    Console.Clear();
                    Console.WriteLine("1. Вывести список всех автомобилей");
                    Console.WriteLine("2. Добавить новый автомобиль");
                    Console.WriteLine("3. Обновить данные автомобиля");
                    Console.WriteLine("4. Удалить автомобиль");
                    Console.WriteLine("5. Фильтр по бюджету");
                    Console.WriteLine("6. Группировать по бренду автомобиля");
                    Console.WriteLine("0. Выход");
                    Console.Write("\nВыберите пункт меню: ");

                    string? input = Console.ReadLine();

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
        /// Очищает консоль, запрашивает у бизнес-логики все автомобили и выводит их список на экран.
        /// </summary>
        /// <param>Метод не принимает входных параметров.</param>
        /// <returns>Метод возвращает значение void. Результатом работы является текстовый вывод списка машин в окно консоли.</returns>
        private static void ShowAllCars()
        {
            Console.Clear();
            List<Car> cars = _logic.GetAll();

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

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
        }

        /// <summary>
        /// Запускает пошаговый ввод бренда и цены с клавиатуры, после чего отправляет данные в бизнес-логику для сохранения.
        /// </summary>
        /// <param>Метод не принимает входных параметров.</param>
        /// <returns>Метод возвращает значение void. Результатом работы является создание новой записи в базе данных и вывод её ID на экран.</returns>
        private static void AddNewCar()
        {
            Console.Clear();
            Car.CarBrand brand = SelectBrandMenu();
            Console.Write("Введите цену автомобиля: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)
            {
                int newId = _logic.Create(brand, price);
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
        /// Запрашивает у пользователя ID машины, проверяет её существование и позволяет изменить бренд и цену.
        /// </summary>
        /// <param>Метод не принимает входных параметров.</param>
        /// <returns>Метод возвращает значение void. Результатом работы является обновление полей существующей машины в базе данных.</returns>
        private static void UpdateCarData()
        {
            Console.Clear();
            Console.Write("Введите ID автомобиля, который хотите изменить: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Car? car = _logic.GetById(id);
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
                        _logic.Update(id, newBrand, newPrice);
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
        /// Запрашивает уникальный ID автомобиля и передает его в бизнес-логику для удаления из базы данных.
        /// </summary>
        /// <param>Метод не принимает входных параметров.</param>
        /// <returns>Метод возвращает значение void. Результатом работы является удаление строки из таблицы базы данных и вывод сообщения об успехе.</returns>
        private static void DeleteCarData()
        {
            Console.Clear();
            List<Car> cars = _logic.GetAll();

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
            Console.Write("Введите ID автомобиля для удаления: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (_logic.Delete(id))
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
        /// Запрашивает максимальную сумму денег и выводит на экран список машин, цена которых не превышает этот лимит.
        /// </summary>
        /// <param>Метод не принимает входных параметров.</param>
        /// <returns>Метод возвращает значение void. Результатом работы является вывод отфильтрованного по цене списка автомобилей.</returns>
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
        /// Получает из бизнес-логики машины, распределенные по брендам, и красиво выводит их группами на экран.
        /// </summary>
        /// <param>Метод не принимает входных параметров.</param>
        /// <returns>Метод возвращает значение void. Результатом работы является древовидный вывод автомобилей, сгруппированных по маркам.</returns>
        private static void GroupByBrand()
        {
            Console.Clear();
            List<Car> allCars = _logic.GetAll();

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
        /// Показывает пользователю список доступных марок машин и считывает его выбор с клавиатуры.
        /// </summary>
        /// <param>Метод не принимает входных параметров.</param>
        /// <returns>Возвращает выбранный пользователем бренд автомобиля в виде значения из перечисления.</returns>
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

                string? choice = Console.ReadLine();
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
