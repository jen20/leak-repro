using System.Windows;
using ReactiveUI;

namespace LeakRepro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IViewFor<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.Router, v => v.RouterHost.Router);

            this.OneWayBind(ViewModel, vm => vm.Router.NavigationStack.Count, v => v.NavStackSize.Text);

            this.BindCommand(ViewModel, vm => vm.AddCommand, v => v.Add);
            this.BindCommand(ViewModel, vm => vm.ResetCommand, v => v.Reset);
        }

        public static readonly DependencyProperty ViewModelProperty;

        static MainWindow()
        {
            ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(MainWindowViewModel), typeof(MainWindow));
        }
            
        public MainWindowViewModel ViewModel
        {
            get { return (MainWindowViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainWindowViewModel)value; }
        }
    }
}
