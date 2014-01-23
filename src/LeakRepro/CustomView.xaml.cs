using System.Windows;
using ReactiveUI;

namespace LeakRepro
{
    /// <summary>
    /// Interaction logic for CustomView.xaml
    /// </summary>
    public partial class CustomView : IViewFor<CustomViewModel>
    {
        public CustomView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.SomeValue, v => v.SomeValue.Text);
        }

        static CustomView()
        {
            ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(CustomViewModel), typeof(CustomView));
        }

        public static readonly DependencyProperty ViewModelProperty;

        public CustomViewModel ViewModel
        {
            get { return (CustomViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (CustomViewModel)value; }
        }
    }
}
