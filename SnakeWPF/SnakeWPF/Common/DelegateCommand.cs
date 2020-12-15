using System;
using System.Windows.Input;

namespace SnakeWPF.Common
{
    
    public class DelegateCommand : ICommand
    {
        #region Fields

        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        #endregion

        #region Constructors

        
        public DelegateCommand(Action<object> execute)
        {
            _execute = execute;
            _canExecute = (x) => { return true; };
        }

        
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Properties
        #endregion

        #region Methods

        
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion
    }
}
