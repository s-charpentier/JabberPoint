using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JabberPoint.View
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _action;
        public RelayCommand(Action action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
            => true;

        public void Execute(object parameter)
            => _action?.Invoke();
    }
    public class RelayCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<T> _action;
        public RelayCommand(Action<T> action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
            => true;

        public void Execute(object parameter)
            => _action?.Invoke((T)parameter);
    }
}
