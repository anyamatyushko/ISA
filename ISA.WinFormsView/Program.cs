using ISA.BusinessLogic;
using ISA.DataAccessLayer;
using ISA.DataAccessLayer.EntityFrameworkCore; 
using ISA.Model; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace ISA.WinFormsView
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            AppDomain.CurrentDomain.SetData("DataDirectory", AppContext.BaseDirectory);
            // 🟢 1. Просим .NET сам определить точный путь к твоей личной папке пользователя (C:\Users\ТвоеИмя)
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            // 🟢 2. Собираем идеальный, чистый путь к файлу базы данных
            string dbPath = System.IO.Path.Combine(userFolder, "MySharedCarDb.mdf");

            // 🟢 3. Подставляем этот готовый путь в строку подключения без всяких знаков %
            string connectionString = $@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=MySharedCarDb;Integrated Security=true;AttachDbFileName={dbPath};";



            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var context = new MyDbContext(optionsBuilder.Options);
            IRepository<Car> repository = new EntityRepository<Car>(context);
            Logic logic = new Logic(repository);

            Application.Run(new MainFormView(logic));
        }
    }
}
