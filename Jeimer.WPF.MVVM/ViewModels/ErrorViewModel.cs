using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Jeimer.WPF.MVVM.ViewModels
{
    public sealed class ErrorViewModel : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public IEnumerable GetErrors(string? propertyName) =>
            _errors.GetValueOrDefault(propertyName!, new List<string>());

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public void AddError(string errorMessage,
                             [CallerMemberName] string? propertyName = default)
        {
            if (_errors.ContainsKey(propertyName!))
                _errors[propertyName!].Add(errorMessage);
            else
                _errors.Add(propertyName!, new List<string> { errorMessage });
        }

        public void ClearErrors([CallerMemberName] string? propertyName = default) => _errors.Remove(propertyName!);

        private void OnErrorsChanged(string? propertyName = default) =>
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}
