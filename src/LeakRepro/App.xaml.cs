using ReactiveUI;

namespace LeakRepro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            RxApp.MutableResolver.Register(() => new CustomView(), typeof (IViewFor<CustomViewModel>));

            var vm = new MainWindowViewModel();
            RxApp.MutableResolver.RegisterConstant(vm, typeof (IScreen));
            var view = new MainWindow {ViewModel = vm};

            view.Show();
        }
    }
}
