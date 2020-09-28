using System;
using System.Windows;
using System.Net;
using System.Net.Mail;

namespace WPFTest
{

    public static class ConfData
    {
        public const string sender_mail = "sonziza@yandex.ru";
        public const string sender_name = "Oleg";
        public const string recipient_mail = "sonziza159@gmail.com";
        public const string recipient_name = "Olejoint";
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EmailSendService service = new EmailSendService();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {

            //указываем адреса эл почты отправителя/получателя
            var mail_sender = new MailAddress(ConfData.sender_mail, ConfData.sender_name);
            var recipient = new MailAddress(ConfData.recipient_mail, ConfData.recipient_name);


            //создаем обьект сообщения отправителя/получателя
            using var message = new MailMessage(mail_sender, recipient)
            {
                Subject = txtTitle.Text,
                Body = txtBody.Text,
            };

            //Создадим клиента-отправителя для общения с почтовым сервером по протоколу SMTP
            using (var client = new SmtpClient("smtp.yandex.ru", 587))
            {
                //забираем с интерфейса строку логина
                var login = TxtLogin.Text;
                //забираем пароль в открытом виде, что нехорошо
                //var password = TxtPass.Password;
                //забираем пароль в защищенном виде
                var password = TxtPass.SecurePassword;

                //Обычно сервер не дает отправлять письма анонимным пользователям
                //Поэтому добавим информацию с нашими учетными данными
                client.Credentials = new NetworkCredential(login, password);
                //Работать будем по SSL шифрованию данных
                if (CheckSSL.IsChecked != null)
                {
                    client.EnableSsl = (bool)CheckSSL.IsChecked;
                }
                //теперь клиенту даем доступ к открытию канала с сервером.
                //Отправляем сообщение
                client.Send(message);
            }
            // Если всё прошло нормально и сервер принял наше сообщение
            // то мы увидим сообщение.
            // При указании неверного адреса сервера/порта,
            // получим ошибку таймаута
            // Если мы ввели неверные учётные данные, или забыли их указать
            // то получим ошибку протокола подключения к серверу
            MessageBox.Show(
                "Письмо отправлено!",
                "Отправка почты"
                );
        }
    }
}
