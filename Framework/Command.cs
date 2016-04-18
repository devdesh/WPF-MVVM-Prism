using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Framework
{
    /// <summary>
    /// Baseclass for Command objects used in ViewModels.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        #region Private Variables

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        #endregion

        #region Conctructor

        /// <summary>
        /// Constructer takes Execute events to register in CommandManager.
        /// </summary>
        /// <param name="execute">Execute method as action.</param>
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
            try
            {
                if (null == execute)
                {
                    throw new NotImplementedException("Execute Not implemented");
                }
                _execute = execute;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Constructer takes Execute and CanExcecute events to register in CommandManager.
        /// </summary>
        /// <param name="execute">Execute method as action.</param>
        /// <param name="canExecute">CanExecute method as return bool type.</param>
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            try
            {
                if (null == execute)
                {
                    _execute = null;
                    throw new NotImplementedException("Execute Not implemented");
                }
                _execute = execute;
                _canExecute = canExecute;
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="parameter">Method parameter.</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// CanExecute method.
        /// </summary>
        /// <param name="parameter">Method parameter.</param>
        /// <returns>Return true if can execute.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// Can Executed Changed Event
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add {  CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

    }
}
