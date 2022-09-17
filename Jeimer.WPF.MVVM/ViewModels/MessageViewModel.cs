namespace Jeimer.WPF.MVVM.ViewModels
{
    public sealed class MessageViewModel : ViewModelBase
    {
        private string _message = string.Empty;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasMessage));
            }
        }

        public bool HasMessage => Message != string.Empty;
    }
}
