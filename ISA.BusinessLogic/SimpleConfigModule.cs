using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using ISA.Model;
using ISA.DataAccessLayer;
using ISA.DataAccessLayer.EntityFrameworkCore;

namespace ISA.BusinessLogic
{
    /// <summary>
    /// Централизованная точка конфигурации зависимостей приложения.
    /// </summary>
    public class SimpleConfigModule : NinjectModule
    {
        private readonly string _connectionString;

        /// <summary>
        /// Инициализирует модуль и принимает строку подключения от слоя View.
        /// </summary>
        public SimpleConfigModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {

            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            Bind<MyDbContext>().ToSelf().WithConstructorArgument("options", optionsBuilder.Options);

            Bind<IRepository<Car>>().To<EntityRepository<Car>>().InSingletonScope();

         
            // Bind<IRepository<Car>>().To<DapperRepository>().WithConstructorArgument("connectionString", _connectionString).InSingletonScope();

            Bind<ICarService>().To<CarService>();
            Bind<ICarAnalytics>().To<CarAnalytics>();
            Bind<ILogic>().To<Logic>();
        }
    }
}