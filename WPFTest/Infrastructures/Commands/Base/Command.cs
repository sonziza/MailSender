using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WPFTest.Infrastructures.Commands.Base
{
    abstract class Command : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExcecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            Excecute(parameter);
        }

        protected bool CanExcecute(object parameter) => true;
        protected abstract void Excecute(object parameter);
    }
}
