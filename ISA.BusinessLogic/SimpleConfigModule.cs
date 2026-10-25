using Ninject.Modules;
using ISA.Model;
using ISA.DataAccessLayer;
using ISA.DataAccessLayer.EntityFrameworkCore;

namespace ISA.BusinessLogic
{
    /// <summary>
    /// Класс конфигурации зависимостей для IoC-контейнера Ninject.
    /// </summary>
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Car>>().To<EntityRepository<Car>>().InSingletonScope();

            //string connectionString = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=MySharedCarDb;Integrated Security=true;";
            // Bind<IRepository<Car>>().To<DapperRepository>().WithConstructorArgument("connectionString", connectionString).InSingletonScope();

            Bind<ILogic>().To<Logic>();
        }
    }
}

