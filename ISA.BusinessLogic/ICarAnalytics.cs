using ISA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA.BusinessLogic
{
    /// <summary>
    /// Интерфейс для выполнения аналитических бизнес-функций.
    /// </summary>
    public interface ICarAnalytics
    {
        /// <summary>
        /// Бизнес-функция для группировки всех существующих автомобилей по их маркам (брендам).
        /// </summary>
        /// <returns>Словарь, где ключом является марка автомобиля, а значением — список автомобилей этой марки.</returns>
        Dictionary<Car.CarBrand, List<Car>> GroupByBrand();

        /// <summary>
        /// Бизнес-функция фильтрации для поиска автомобилей, стоимость которых не превышает заданный бюджет покупателя.
        /// </summary>
        /// <param name="maxBudget">Максимальная сумма денег (бюджет), которую готов потратить покупатель.</param>
        /// <returns>Список, содержащий автомобили, подходящие под указанный ценовой лимит.</returns>
        List<Car> GetCarByBudget(decimal maxBudget);
    }
}
