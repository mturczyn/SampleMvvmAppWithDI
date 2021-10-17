using SampleMvvmAppWithDI.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleMvvmAppWithDI.Abstractions
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        private readonly Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

        public event PropertyChangedEventHandler PropertyChanged;

        #region Command get and set for view models

        protected ICommand Command(Action execute, [CallerMemberName] string propertyName = "")
        {
            if (_commands.ContainsKey(propertyName))
            {
                return _commands[propertyName];
            }
            var command = new RelayCommand(execute);
            _commands.Add(propertyName, command);
            return command;
        }

        protected ICommand Command<T>(Action<T> execute, [CallerMemberName] string propertyName = "")
        {
            if (_commands.ContainsKey(propertyName))
            {
                return _commands[propertyName];
            }
            var command = new RelayCommand<T>(execute);
            _commands.Add(propertyName, command);
            return command;
        }

        protected ICommand Command(Func<Task> execute, [CallerMemberName] string propertyName = "")
        {
            if (_commands.ContainsKey(propertyName))
            {
                return _commands[propertyName];
            }
            var command = new AsyncRelayCommand(execute);
            _commands.Add(propertyName, command);
            return command;
        }

        protected ICommand Command<T>(Func<T, Task> execute, [CallerMemberName] string propertyName = "")
        {
            if (_commands.ContainsKey(propertyName))
            {
                return _commands[propertyName];
            }
            var command = new AsyncRelayCommand<T>(execute);
            _commands.Add(propertyName, command);
            return command;
        }

        #endregion

        /// <summary>
        /// Returns whether property changed event was raised.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Value to be set.</param>
        /// <param name="propertyName">Name of property.</param>
        /// <returns>If <see cref="PropertyChanged"/> event was raised for property.</returns>
        protected bool Set<T>(T value, [CallerMemberName] string propertyName = "")
        {
            if (_properties.ContainsKey(propertyName))
            {
                var propertyValue = (T)_properties[propertyName];
                if (EqualityComparer<T>.Default.Equals(value, propertyValue))
                {
                    return false;
                }

                _properties[propertyName] = value;
                RaisePropertyChanged(propertyName);
                return true;
            }
            else
            {
                _properties.Add(propertyName, value);
                RaisePropertyChanged(propertyName);
                return true;
            }
        }

        protected T Get<T>([CallerMemberName] string propertyName = "")
        {
            if (_properties.ContainsKey(propertyName))
            {
                return (T)_properties[propertyName];
            }
            else
            {
                return default(T);
            }
        }

        protected void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
