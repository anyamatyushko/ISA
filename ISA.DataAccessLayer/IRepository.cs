using ISA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA.DataAccessLayer
{
    public interface IRepository<T> where T: IDomainObject
    {
        int AddCar(T item);
        T GetCarById(int id);
        List<T> GetCars();
        bool UpdateCar(T item);
        bool DeleteCar(int id);

    }
}
