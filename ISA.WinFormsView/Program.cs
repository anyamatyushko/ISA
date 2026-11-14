using System;
using System.IO;
using System.Windows.Forms;
using ISA.Presenter;

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

            // 1. Создаем главную форму
            var mainForm = new MainFormView();

            // 2. Передаем её в точку сборки (в Презентер), чтобы привязать логику и события
            AppComposer.Compose(mainForm, connectionString);

            // 3. Запускаем окно
            Application.Run(mainForm);
        }
    }
}
