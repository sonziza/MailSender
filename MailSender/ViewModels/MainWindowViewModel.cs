using System;
using System.Collections.Generic;
using System.Text;
using MailSender.Infrastructures.Commands;
using System.Windows.Input;
using System.Windows;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Главное окно программы";
        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        //private ICommand _ShowDialogCommand;
        //public ICommand ShowDialogCommand => _ShowDialogCommand ??= new LambdaCommand(OnShowDialogExecuted);

        //private void OnShowDialogExecuted(object parameter)
        //{
        //    var message = parameter as string ?? "Hello WOrld!";
        //    MessageBox.Show(message, "Окно сообщения от первой команды");
        //}
    }
}
