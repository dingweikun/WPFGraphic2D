﻿using System;
using System.Windows.Input;

namespace DrawingDemo.Common
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute ?? (x => true);
        }

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }


        public bool CanExecute(object parameter)=> _canExecute(parameter);

        public void Execute(object parameter)=> _execute(parameter);

    }
}
