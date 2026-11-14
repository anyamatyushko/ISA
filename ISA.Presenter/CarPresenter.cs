using System;
using System.Collections.Generic;
using System.Linq;
using ISA.BusinessLogic;
using ISA.Model;
using ISA.Shared;

namespace ISA.Presenter
{
    /// <summary>
    /// Презентер, связывающий представление (IView) и бизнес-логику (ILogic) через события.
    /// </summary>
    public class CarPresenter
    {
        private readonly IView _view;
        private readonly ILogic _logic;

        /// <summary>
        /// Инициализирует презентер и подписывает его на события экрана и модели.
        /// </summary>
        /// <param name="view">Абстракция пользовательского интерфейса (Консоль или WinForms).</param>
        /// <param name="logic">Фасад бизнес-логики приложения.</param>
        public CarPresenter(IView view, ILogic logic)
        {
            _view = view;
            _logic = logic;

            _view.OnLoadAllCars += LoadAllCars;
            _view.OnCreateCar += CreateCar;
            _view.OnUpdateCar += UpdateCar;
            _view.OnDeleteCar += DeleteCar;
            _view.OnFilterByBudget += FilterByBudget;
            _view.OnGroupByBrand += GroupByBrand;
       
            _logic.OnOperationCompleted += HandleModelNotification;
        }

        /// <summary>
        /// Обрабатывает уведомления от бизнес-логики и передает их на экран.
        /// </summary>
        private void HandleModelNotification(string message)
        {
            _view.ShowMessage(message);
        }

        /// <summary>
        /// Загружает все автомобили из логики, переводит в DTO и отправляет на отрисовку.
        /// </summary>
        private void LoadAllCars()
        {
            var cars = _logic.GetAll();
            var dtos = cars.Select(MapToDto).ToList();
            _view.DisplayCars(dtos);
        }

        /// <summary>
        /// Переводит DTO-данные в доменный тип и передает запрос на создание автомобиля в логику.
        /// </summary>
        private void CreateCar(CarBrandDto brandDto, decimal price)
        {
            try
            {
                var modelBrand = (Car.CarBrand)Enum.Parse(typeof(Car.CarBrand), brandDto.ToString());
                _logic.Create(modelBrand, price);
                LoadAllCars(); // Обновляем список на экране после добавления
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Ошибка при создании: {ex.Message}");
            }
        }

        /// <summary>
        /// Передает запрос на обновление данных автомобиля в логику.
        /// </summary>
        private void UpdateCar(int id, CarBrandDto brandDto, decimal price)
        {
            try
            {
                var modelBrand = (Car.CarBrand)Enum.Parse(typeof(Car.CarBrand), brandDto.ToString());
                _logic.Update(id, modelBrand, price);
                LoadAllCars(); // Обновляем список на экране после редактирования
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Ошибка при обновлении: {ex.Message}");
            }
        }

        /// <summary>
        /// Передает запрос на удаление автомобиля по ID в логику.
        /// </summary>
        private void DeleteCar(int id)
        {
            _logic.Delete(id);
            LoadAllCars(); // Обновляем список на экране после удаления
        }

        /// <summary>
        /// Запрашивает отфильтрованные по бюджету автомобили и отправляет их на экран.
        /// </summary>
        private void FilterByBudget(decimal maxBudget)
        {
            var cars = _logic.GetCarByBudget(maxBudget);
            var dtos = cars.Select(MapToDto).ToList();
            _view.DisplayCars(dtos);
        }

        /// <summary>
        /// Запрашивает сгруппированные по брендам автомобили, конвертирует словарь в DTO и передает на экран.
        /// </summary>
        private void GroupByBrand()
        {
            var grouped = _logic.GroupByBrand();
            var groupedDtos = new Dictionary<CarBrandDto, List<CarDto>>();

            foreach (var item in grouped)
            {
                var brandDto = (CarBrandDto)Enum.Parse(typeof(CarBrandDto), item.Key.ToString());
                groupedDtos[brandDto] = item.Value.Select(MapToDto).ToList();
            }

            _view.DisplayGroupedCars(groupedDtos);
        }

        /// <summary>
        /// Вспомогательный метод-маппер: преобразует доменную модель Car в DTO-объект для View.
        /// </summary>
        private CarDto MapToDto(Car car)
        {
            return new CarDto
            {
                Id = car.Id,
                Brand = (CarBrandDto)Enum.Parse(typeof(CarBrandDto), car.Brand.ToString()),
                Price = car.Price
            };
        }
    }
}
