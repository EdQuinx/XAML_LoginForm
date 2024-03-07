using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XAML_LoginForm.ViewModels
{
    public class ViewModelCommand<T> : ICommand
    {
        //Fields
        private readonly Predicate<T>? _canExecute;
        private readonly Action<T>? _execute;

        //Contructors
        public ViewModelCommand(Action<T> execute)
        {
            _execute = execute;
            _canExecute = null;
        }
        public ViewModelCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _canExecute = canExecute;
            _execute = execute;
        }

        //Methods
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        //Events
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}