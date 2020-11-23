using MailSender.ViewModels.Base;
using System.Collections.ObjectModel;
using MailSender.Models;
using MailSender.Data;
using System.Windows.Input;
using MailSender.Infrastructures.Commands;
using System.Windows;
using System.Linq;
using MailSender.lib.Interfaces;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly IMailService _MailService;

        private string _Title = "Рассыльщик почты";
        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private ObservableCollection<Server> _Servers;
        private ObservableCollection<Sender> _Senders;
        private ObservableCollection<Recipient> _Recipients;
        private ObservableCollection<Message> _Messages;

        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            set => Set(ref _Servers, value);
        }

        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            set => Set(ref _Senders, value);
        }

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }

        public ObservableCollection<Message> Messages
        {
            get => _Messages;
            set => Set(ref _Messages, value);
        }

        /// <summary>
        /// Обеспечиваем возможность выбора текущего элемента в списках данных
        /// </summary>
        private Server _SelectedServer;

        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }

        private Sender _SelectedSender;

        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }

        private Recipient _SelectedRecipient;

        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }

        private Message _SelectedMessage;

        public Message SelectedMessage
        {
            get => _SelectedMessage;
            set => Set(ref _SelectedMessage, value);
        }
        #region Команды
        #region CreateNewServerCommand - создать новый сервер

        private ICommand _CreateNewServerCommand;

        public ICommand CreateNewServerCommand => _CreateNewServerCommand
            ??= new LambdaCommand(OnCreateNewServerCommandExecuted, CanCreateNewServerCommandExecute);

        private bool CanCreateNewServerCommandExecute(object p) => true;

        private void OnCreateNewServerCommandExecuted(object p)
        {
            if (!ServerEditDialog.Create(
                out string address,
                out int port,
                out bool useSSL,
                out string login,
                out string password,
                out string description
                )) return;

            var server = new Server
            {
                Address = address,
                Port = port,
                UseSSL = useSSL,
                Login = login,
                Password = password,
                Description = description,
            };
            Servers.Add(server);
            //MessageBox.Show("Создание нового сервера!", "Управление серверами");
        }

        #endregion

        #region EditServerCommand - редактировать текущий сервер

        private ICommand _EditServerCommand;

        public ICommand EditServerCommand => _EditServerCommand
            ??= new LambdaCommand(OnEditServerCommandExecuted, CanEditServerCommandExecute);

        private bool CanEditServerCommandExecute(object p) => p is Server || SelectedServer != null;

        private void OnEditServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;

            MessageBox.Show($"Редактирование сервера {server.Address}!", "Управление серверами");
        }

        #endregion

        #region DeleteServerCommand - удалить текущий сервер

        private ICommand _DeleteServerCommand;

        public ICommand DeleteServerCommand => _DeleteServerCommand
            ??= new LambdaCommand(OnDeleteServerCommandExecuted, CanDeleteServerCommandExecute);

        private bool CanDeleteServerCommandExecute(object p) => p is Server || SelectedServer != null;

        private void OnDeleteServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;

            Servers.Remove(server);
            SelectedServer = Servers.FirstOrDefault();

            //MessageBox.Show($"Удаление сервера {server.Address}!", "Управление серверами");
        }

        #endregion

        #region SendMailMessageCommand - отправка почты
        /// <summary>Отправка почты</summary>
        private ICommand _SendMailCommand;

        /// <summary>Отправка почты</summary>
        public ICommand SendMailCommand => _SendMailCommand
            ??= new LambdaCommand(OnSendMailCommandExecuted, CanSendMailCommandExecute);

        /// <summary>Проверка возможности выполнения - Отправка почты</summary>
        private bool CanSendMailCommandExecute(object p)
        {
            if (SelectedServer is null) return false;
            if (SelectedSender is null) return false;
            if (SelectedRecipient is null) return false;
            if (SelectedMessage is null) return false;
            return true;
        }

        /// <summary>Логика выполнения - Отправка почты</summary>
        private void OnSendMailCommandExecuted(object p)
        {
            var server = SelectedServer;
            var sender = SelectedSender;
            var recipient = SelectedRecipient;
            var message = SelectedMessage;

            var mail_sender = _MailService.GetSender(server.Address, server.Port, server.UseSSL, server.Login, server.Password);
            mail_sender.Send(sender.Address, recipient.Address, message.Subject, message.Body);

            //Statistic.MessageSended();
        }
        #endregion

        #endregion


        public MainWindowViewModel(IMailService MailService, MailSenderDBContext db)
        {
            //   при загрузке приложения контейнер сервисов как только получит запрос на создание
            //   модели - представления главного окна, прежде чем создать её сперва создаст SmtpMailService и
            //   передав объект этого сервиса в конструктор модели-представления создаст её
            _MailService = MailService;
            //прицепляем списки объектов к коллекциям MainWindowVM
            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messages);

            var recipients = db.Recipients.ToArray();


        }
    }
}
