using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA.BusinessLogic
{
    /// <summary>
    /// Единая точка доступа (Матрешка/Фасад) для работы с системой автомобилей.
    /// Объединяет в себе функции учета (ICarService) и аналитики (ICarAnalytics).
    /// </summary>
    public interface ILogic: ICarService, ICarAnalytics
    {

    }
}
