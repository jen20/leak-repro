using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace LeakRepro
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public IRoutingState Router { get; private set; }

        public ReactiveCommand AddCommand { get; private set; }
        public ReactiveCommand ResetCommand { get; private set; }

        public MainWindowViewModel()
        {
            Router = new RoutingState();

            var canAdd = this.WhenAnyValue(vm => vm.Router.NavigationStack.Count).Select(count => count == 0);

            AddCommand = new ReactiveCommand(canAdd);
            AddCommand.Subscribe(_ => Router.Navigate.Execute(new CustomViewModel(this) { SomeValue = "Trololol" }));

            var canReset = this.WhenAnyValue(vm => vm.Router.NavigationStack.Count).Select(count => count > 0);

            ResetCommand = new ReactiveCommand(canReset);
            ResetCommand.Subscribe(_ => Router.NavigateBack.Execute(null));
        }
    }
}