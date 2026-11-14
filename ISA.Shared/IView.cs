using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISA.Shared.CarDto;

namespace ISA.Shared
{
    public interface IView
    {
        // События экрана (генерирует View, слушает Presenter)
        event Action? OnLoadAllCars;
        event Action<CarBrandDto, decimal>? OnCreateCar;
        event Action<int, CarBrandDto, decimal>? OnUpdateCar;
        event Action<int>? OnDeleteCar;
        event Action<decimal>? OnFilterByBudget;
        event Action? OnGroupByBrand;


        // Методы отрисовки (вызывает Presenter, выполняет View)
        void DisplayCars(List<CarDto> cars);
        void DisplayGroupedCars(Dictionary<CarBrandDto, List<CarDto>> groupedCars);
        void ShowMessage(string message);
    }
}
