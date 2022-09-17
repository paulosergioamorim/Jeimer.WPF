namespace Jeimer.WPF.MVVM.Commands
{
    public abstract class AsyncCommand : CommandBase
    {
        private bool _disposed = true;

        private bool Disposed
        {
            get => _disposed;
            set
            {
                _disposed = value;
                OnCanExecuteChanged();
            }
        }
        
        public override bool CanExecute(object? parameter) => Disposed;

        protected abstract Task ExecuteAsync(object? parameter);

        public override async void Execute(object? parameter)
        {
            Disposed = false;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                Disposed = true;
            }
        }
    }
    
    public abstract class AsyncCommand<TException> : CommandBase where TException : Exception
    {
        private readonly Action<TException> _exception;
        private bool _disposed = true;

        private bool Disposed
        {
            get => _disposed;
            set
            {
                _disposed = value;
                OnCanExecuteChanged();
            }
        }

        protected AsyncCommand(Action<TException> exception) => _exception = exception;

        public override bool CanExecute(object? parameter) => Disposed;

        protected abstract Task ExecuteAsync(object? parameter);

        public override async void Execute(object? parameter)
        {
            Disposed = false;

            try
            {
                await ExecuteAsync(parameter);
            }
            catch (TException e)
            {
                _exception(e);
            }
            finally
            {
                Disposed = true;
            }
        }
    }
}
