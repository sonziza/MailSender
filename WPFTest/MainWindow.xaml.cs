using System;
using System.Windows;
using System.Net;
using System.Net.Mail;

namespace WPFTest
{

    public static class ConfData
    {
        public const int server_port = 25;
        public const string server_address = "smtp.yandex.ru";
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object Sender, RoutedEventArgs e)
        {
            EmailSendService service = new EmailSendService() { 
                Login = TxtLogin.Text, 
                Password = TxtPass.Password,
                ServerAddress = ConfData.server_address,
                ServerPort = ConfData.server_port, 
                UseSSL = (bool)CheckSSL.IsChecked, 
            };
            Models.Sender sender = new Models.Sender()
            {
                Name = TxtLogin.Text,
                Address = TxtSenderMail.Text
            };
            Models.Recipient recipient = new Models.Recipient()
            {
                Name = TxtRecipient.Text,
                Address = TxtRecipMail.Text
            };
            Models.Message message = new Models.Message()
            {
                Title = txtTitle.Text,
                Body = txtBody.Text
            };

            try
            {
                service.SendMessage(sender.Address, recipient.Address, message.Title, message.Body);
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
