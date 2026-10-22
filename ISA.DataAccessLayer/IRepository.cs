using ISA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA.DataAccessLayer
{

    public interface IRepository<T> where T : IDomainObject
    {
        /// <summary>
        /// Добавляет новый объект в таблицу базы данных.
        /// </summary>
        /// <param name="item">Объект, который необходимо сохранить.</param>
        /// <returns>Числовой идентификатор (ID) созданной записи или количество затронутых строк.</returns>
        int Create(T item);

        /// <summary>
        /// Возвращает существующую запись из таблицы базы данных по её уникальному идентификатору (ID).
        /// </summary>
        /// <param name="id">Числовой уникальный идентификатор искомой записи.</param>
        /// <returns>Найденный объект типа <typeparamref name="T"/> или null, если запись не найдена.</returns>
        T GetById(int id);

        /// <summary>
        /// Возвращает список всех записей из таблицы базы данных.
        /// </summary>
        /// <returns>Список объектов типа <typeparamref name="T"/>.</returns>
        List<T> GetAll();

        /// <summary>
        /// Обновляет данные существующей записи в таблице базы данных.
        /// </summary>
        /// <param name="item">Объект с обновленными данными.</param>
        /// <returns>Значение true, если запись была успешно обновлена; в противном случае — false.</returns>
        bool Update(T item);

        /// <summary>
        /// Удаляет существующую запись из таблицы базы данных по её уникальному идентификатору (ID).
        /// </summary>
        /// <param name="id">Числовой уникальный идентификатор записи, которую необходимо стереть.</param>
        /// <returns>Значение true, если запись была успешно найдена и удалена из таблицы; в противном случае — false.</returns>
        bool Delete(int id);
    }
}
