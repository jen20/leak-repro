using ReactiveUI;

namespace LeakRepro
{
    public class CustomViewModel : ReactiveObject, IRoutableViewModel
    {
        public CustomViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
        }

        private string _someValue;

        public string SomeValue
        {
            get { return _someValue; }
            set { this.RaiseAndSetIfChanged(ref _someValue, value); }
        }

        public string UrlPathSegment { get { return "apath"; } }
        public IScreen HostScreen { get; private set; }
    }
}