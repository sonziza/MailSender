using MailSender.Models;
using System.Windows;
using MailSender.lib;
using System.Net.Mail;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnToPlanner_Click(object Sender, RoutedEventArgs e)
        {
            tabList.SelectedItem = tbPlanner;
        }

        private void btnNow_Click(object Sender, RoutedEventArgs e)
        {
            var sender = SendersList.SelectedItem as Sender;
            if(sender is null) return;
            if (!(RecipientsList.SelectedItem is Recipient recipient)) return;
            if (!(ServersList.SelectedItem is Server server)) return;
            var message = MessagesList.SelectedItem as Message;
            if ((message is null) || (message.Body is null))
            {
                MessageBox.Show("Кажется, у вас пустое сообщение", "Ошибка отправки письма", MessageBoxButton.OK);
                tabList.SelectedItem = tbMessages;
                return;
            }

            var send_service = new MailSenderService
            {
                ServerAddress = server.Address,
                ServerPort = server.Port,
                UseSSL = server.UseSSL,
                Login = server.Login,
                Password = server.Password,
            };

            try
            {
                send_service.SendMessage(sender.Address, recipient.Address, message.Subject, message.Body);
            }
            catch (SmtpException error)
            {
                MessageBox.Show(
                    "Ошибка при отправке почты " + error.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
