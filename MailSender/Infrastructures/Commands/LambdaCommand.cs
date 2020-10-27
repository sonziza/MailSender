using System;
using System.Collections.Generic;
using System.Text;
using MailSender.Infrastructures.Commands.Base;

namespace MailSender.Infrastructures.Commands
{
    /// <summary>
    /// Для упрощения использования команд в этом сценарии создадим класс команды, в которую
    ///   можно будет передать делегаты методов модели-представления
    /// </summary>
    class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;
        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }
        protected override void Execute(object parameter) => _Execute(parameter);
        protected override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
    }
}
