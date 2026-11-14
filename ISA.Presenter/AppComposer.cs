using Ninject;
using ISA.BusinessLogic;
using ISA.Shared;

namespace ISA.Presenter
{
    /// <summary>
    /// Точка сборки (Composition Root) приложения, вынесенная в слой Презентера.
    /// Связывает переданное представление (IView) с бизнес-логикой через DI-контейнер.
    /// </summary>
    public static class AppComposer
    {
        public static void Compose(IView view, string connectionString)
        {
            // 1. Инициализируем Ninject с модулем конфигурации БД и Бизнес-логики
            var kernel = new StandardKernel(new SimpleConfigModule(connectionString));

            // 2. Привязываем переданный экземпляр экрана (Консоль или WinForms) к интерфейсу IView
            kernel.Bind<IView>().ToConstant(view);

            // 3. Собираем Презентер! Ninject сам создаст Logic, возьмет наш view 
            // и подпишет CarPresenter на все события.
            kernel.Get<CarPresenter>();
        }
    }
}

