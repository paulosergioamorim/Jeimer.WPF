using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Jeimer.WPF.MVVM.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = default) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public virtual void Dispose()
        {
        }
    }
}
