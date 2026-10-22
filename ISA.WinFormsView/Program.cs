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
         
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


            string dbPath = System.IO.Path.Combine(userFolder, "MySharedCarDb.mdf");

            string connectionString = $@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=MySharedCarDb;Integrated Security=true;AttachDbFileName={dbPath};";



            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var context = new MyDbContext(optionsBuilder.Options);
            //IRepository<Car> repository = new EntityRepository<Car>(context);
            IRepository<Car> repository = new DapperRepository(connectionString);
            Logic logic = new Logic(repository);


            Application.Run(new MainFormView(logic));
        }
    }
}
