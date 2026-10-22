using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using Dapper;
using ISA.Model;

namespace ISA.DataAccessLayer
{
    public class DapperRepository : IRepository<Car>
    {
        private readonly string _connectionString;
        public DapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Внутренний инфраструктурный метод для выполнения SQL-скриптов действия (INSERT, UPDATE, DELETE), не возвращающих наборы строк.
        /// </summary>
        /// <param name="script">Текст SQL-запроса для выполнения.</param>
        /// <returns>Количество строк, затронутых выполненным запросом в базе данных.</returns>
        private int UseScript(string script)
        {
            if (string.IsNullOrEmpty(script)) return 0;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Execute(script);
            }
        }

        /// <summary>
        /// Добавляет новую запись автомобиля в базу данных и возвращает его сгенерированный идентификатор.
        /// </summary>
        /// <param name="item">Объект автомобиля (Car), содержащий данные для сохранения.</param>
        /// <returns>Уникальный идентификатор (Id) созданной записи.</returns>
        public int Create(Car item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                string script = "INSERT INTO Cars (Brand, Price) VALUES (@Brand, @Price); SELECT CAST(SCOPE_IDENTITY() as int);";

       
                return db.Query<int>(script, new { Brand = (int)item.Brand, Price = item.Price }).Single();
            }
        }

        /// <summary>
        /// Производит поиск и выборку одного автомобиля по его уникальному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор искомого автомобиля.</param>
        /// <returns>Объект автомобиля (Car) в случае успеха, либо null, если запись не найдена.</returns>
        public Car GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Car>("SELECT * FROM Cars WHERE Id = " + id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Извлекает из базы данных полный список всех зарегистрированных автомобилей.
        /// </summary>
        /// <returns>Список (List) объектов Car.</returns>
        public List<Car> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Car>("SELECT * FROM Cars").ToList();
            }
        }

        /// <summary>
        /// Обновляет текстовые и числовые поля существующего автомобиля в базе данных.
        /// </summary>
        /// <param name="item">Объект автомобиля с измененными свойствами и заполненным Id.</param>
        /// <returns>Значение true, если запись в БД успешно обновлена, иначе false.</returns>
        public bool Update(Car item)
        {
         
            string script = "UPDATE Cars SET Brand = " + (int)item.Brand + ", Price = " + item.Price + " WHERE Id = " + item.Id + ";";

    
            int rows = UseScript(script);
            return rows > 0;
        }

        /// <summary>
        /// Безвозвратно удаляет запись автомобиля из базы данных по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого автомобиля.</param>
        /// <returns>Значение true, если строка удалена из таблицы, иначе false.</returns>
        public bool Delete(int id)
        {
            string script = "DELETE FROM Cars WHERE Id = " + id;
            int rows = UseScript(script);
            return rows > 0;
        }
    }
}