using System;
using System.Windows;
using System.Net;
using System.Net.Mail;

namespace WPFTest
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

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            //указываем адреса эл почты отправителя/получателя
            var mail_sender = new MailAddress("sonziza@yandex.ru", "Oleg");
            var recipient = new MailAddress("sonziza159@gmail.com", "Olejoint");

            //создаем обьект сообщения отправителя/получателя
            using var message = new MailMessage(mail_sender, recipient)
            {
                Subject = "Это тестовое сообщение",
                Body = "Проверка тестового сообщения. Просьба не отвечать на него!",
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
                client.EnableSsl = true;
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
