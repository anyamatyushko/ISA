using ISA.DataAccessLayer.EntityFrameworkCore;
using ISA.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA.DataAccessLayer.EntityFrameworkCore
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class, IDomainObject
    {
        private readonly MyDbContext _context;

        public EntityRepository(MyDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Добавляет (создает) новую запись сущности в соответствующую таблицу базы данных.
        /// </summary>
        /// <param name="item">Объект сущности, заполненный данными, который необходимо сохранить.</param>
        /// <returns>Уникальный числовой идентификатор (ID), который база данных автоматически сгенерировала и присвоила созданной записи.</returns>
        public int Create(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            _context.SaveChanges();

            return item.Id;
        }



        /// <summary>
        /// Находит одну конкретную запись в таблице базы данных по её уникальному идентификатору (ID).
        /// </summary>
        /// <param name="id">Числовой уникальный идентификатор искомой записи.</param>
        /// <returns>Найденный объект сущности типа TEntity, если запись обнаружена; в противном случае возвращает null.</returns>
        public TEntity? GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }



        /// <summary>
        /// Извлекает абсолютно все строки из таблицы базы данных и преобразует их в стандартный список C#.
        /// </summary>
        /// <param>Метод не принимает входных параметров.</param>
        /// <returns>Список объектов TEntity, содержащий все хранящиеся в таблице записи базы данных.</returns>
        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }


        /// <summary>
        /// Обновляет измененные поля существующего в базе данных объекта на основе совпадения его идентификатора.
        /// </summary>
        /// <param name="item">Объект сущности с новыми измененными данными, который нужно обновить в базе.</param>
        /// <returns>Значение true, если запись с таким ID существовала и данные успешно перезаписались в базе; в противном случае — false.</returns>
        public bool Update(TEntity item)
        {
            _context.Set<TEntity>().Update(item);
            int rowsAffected = _context.SaveChanges();

            return rowsAffected > 0;
        }


        /// <summary>
        /// Удаляет существующую запись из таблицы базы данных по её уникальному идентификатору (ID).
        /// </summary>
        /// <param name="id">Числовой уникальный идентификатор записи, которую необходимо стереть.</param>
        /// <returns>Значение true, если запись была успешно найдена и удалена из таблицы; в противном случае — false.</returns>
        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) return false;

            _context.Set<TEntity>().Remove(item);
            int rowsAffected = _context.SaveChanges();

            return rowsAffected > 0;
        }
    }
}
