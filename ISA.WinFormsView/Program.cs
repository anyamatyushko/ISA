using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Ninject;
using ISA.BusinessLogic;
using ISA.DataAccessLayer;
using ISA.DataAccessLayer.EntityFrameworkCore;
using ISA.Model;

namespace ISA.WinFormsView
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            AppDomain.CurrentDomain.SetData("DataDirectory", AppContext.BaseDirectory);
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string dbPath = Path.Combine(userFolder, "MySharedCarDb.mdf");
            string connectionString = $@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=MySharedCarDb;Integrated Security=true;AttachDbFilename={dbPath};";

            // Здесь тоже настраиваю Ninject
            var kernel = new StandardKernel();

            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            kernel.Bind<MyDbContext>().ToSelf().WithConstructorArgument("options", optionsBuilder.Options);
            kernel.Bind<IRepository<Car>>().To<EntityRepository<Car>>().InSingletonScope(); //Для репозитория оставляю синглтон

            kernel.Bind<ILogic>().To<Logic>();

            ILogic logic = kernel.Get<ILogic>();

            Application.Run(new MainFormView(logic));
        }
    }
}

