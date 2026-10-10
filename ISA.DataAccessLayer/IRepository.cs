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
        int Create(T item);
        T GetById(int id);
        List<T> GetAll();
        bool Update(T item);
        bool Delete(int id);

    }
}



