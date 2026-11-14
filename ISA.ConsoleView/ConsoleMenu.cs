using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ninject;
using ISA.BusinessLogic;
using ISA.Presenter;
using ISA.Shared;


namespace ISA.ConsoleView
{
    class Program : IView
    {
        private List<CarDto> _lastLoadedCars = new List<CarDto>();

        public event Action? OnLoadAllCars;
        public event Action<CarBrandDto, decimal>? OnCreateCar;
        public event Action<int, CarBrandDto, decimal>? OnUpdateCar;
        public event Action<int>? OnDeleteCar;
        public event Action<decimal>? OnFilterByBudget;
        public event Action? OnGroupByBrand;

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppContext.BaseDirectory);

            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string dbPath = Path.Combine(userFolder, "MySharedCarDb.mdf");
            string connectionString = $@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=MySharedCarDb;Integrated Security=true;AttachDbFileName={dbPath};";

            // 1. Создаем консольное представление
            var program = new Program();

            // 2. Передаем его в точку сборки в Презентере
            AppComposer.Compose(program, connectionString);

            // 3. Запускаем меню
            program.Run();
        }

        /// <summary>
        /// Запускает основной цикл консольного меню приложения.
        /// </summary>
        public void Run()
        {
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
        /// Выводит переданный список автомобилей в окно консоли.
        /// </summary>
        public void DisplayCars(List<CarDto> cars)
        {
            _lastLoadedCars = cars;

            if (cars.Count == 0)
            {
                Console.WriteLine("Список пуст.");
            }
            else
            {
                foreach (CarDto car in cars)
                {
                    Console.WriteLine($"ID: {car.Id}  Бренд: {car.Brand}  Цена: {car.Price:C}");
                }
            }
        }

        /// <summary>
        /// Выводит сгруппированный по маркам список автомобилей в окно консоли.
        /// </summary>
        public void DisplayGroupedCars(Dictionary<CarBrandDto, List<CarDto>> groupedCars)
        {
            if (groupedCars.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            foreach (var group in groupedCars)
            {
                Console.WriteLine($"--- Бренд: {group.Key} (Количество: {group.Value.Count}) ---");
                foreach (CarDto car in group.Value)
                {
                    Console.WriteLine($"  ID: {car.Id}  Цена: {car.Price:C}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Выводит информационное сообщение от Презентера или Модели на экран.
        /// </summary>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

     

        /// <summary>
        /// Очищает консоль и запрашивает через событие вывод всех автомобилей.
        /// </summary>
        private void ShowAllCars()
        {
            Console.Clear();
            OnLoadAllCars?.Invoke();

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
        }

        /// <summary>
        /// Запускает пошаговый ввод бренда и цены с клавиатуры и отправляет событие создания.
        /// </summary>
        private void AddNewCar()
        {
            Console.Clear();
            CarBrandDto brand = SelectBrandMenu();
            Console.Write("Введите цену автомобиля: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)
            {
                OnCreateCar?.Invoke(brand, price);
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
        private void UpdateCarData()
        {
            Console.Clear();
            OnLoadAllCars?.Invoke();

            Console.Write("\nВведите ID автомобиля, который хотите изменить: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                CarDto? car = _lastLoadedCars.FirstOrDefault(c => c.Id == id);
                if (car == null)
                {
                    Console.WriteLine("Автомобиль с таким ID не найден.");
                }
                else
                {
                    Console.WriteLine($"Вы редактируете: {car.Brand} Текущая цена: {car.Price:C}");
                    CarBrandDto newBrand = SelectBrandMenu();

                    Console.Write("Введите новую цену: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newPrice) && newPrice >= 0)
                    {
                        OnUpdateCar?.Invoke(id, newBrand, newPrice);
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
        /// Выводит список машин, запрашивает ID автомобиля и отправляет событие удаления.
        /// </summary>
        private void DeleteCarData()
        {
            Console.Clear();
            OnLoadAllCars?.Invoke();

            Console.Write("\nВведите ID автомобиля для удаления: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                OnDeleteCar?.Invoke(id);
            }
            else
            {
                Console.WriteLine("Неверный формат ID.");
            }

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadKey();
        }

        /// <summary>
        /// Запрашивает максимальную сумму денег и отправляет событие фильтрации по бюджету.
        /// </summary>
        private void FilterCarsByBudget()
        {
            Console.Clear();
            Console.Write("Введите максимальный бюджет: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal maxBudget) && maxBudget >= 0)
            {
                OnFilterByBudget?.Invoke(maxBudget);
            }
            else
            {
                Console.WriteLine("Некорректное значение бюджета.");
            }

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadKey();
        }

        /// <summary>
        /// Очищает консоль и отправляет событие группировки автомобилей по бренду.
        /// </summary>
        private void GroupByBrand()
        {
            Console.Clear();
            OnGroupByBrand?.Invoke();

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
        }

        /// <summary>
        /// Вспомогательное меню выбора марки автомобиля из перечисления CarBrandDto.
        /// </summary>
        private CarBrandDto SelectBrandMenu()
        {
            while (true)
            {
                Console.WriteLine("\nДоступные марки автомобилей:");
                var brands = (CarBrandDto[])Enum.GetValues(typeof(CarBrandDto));
                for (int i = 0; i < brands.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {brands[i]}");
                }

                Console.Write("Выберите номер марки: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= brands.Length)
                {
                    return brands[choice - 1];
                }

                Console.WriteLine("Неверный выбор. Повторите ввод.");
            }
        }

    }
}
