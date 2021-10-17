using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleMvvmAppWithDI.Abstractions.Commands
{
    public class AsyncRelayCommand : ICommand
    {
        readonly Func<Task> _execute;

        readonly Predicate<object> _canExecute;

        public AsyncRelayCommand(Func<Task> execute) : this(execute, null) { }

        public AsyncRelayCommand(Func<Task> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute; 
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public async void Execute(object parameter) { await _execute(); }
    }
}
