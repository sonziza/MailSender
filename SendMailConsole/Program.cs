using System;
using System.Net;
using System.Net.Mail;

namespace SendMailConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //указываем адреса эл почты отправителя/получателя
            var sender = new MailAddress("sonziza@yandex.ru", "Oleg");
            var recipient = new MailAddress("sonziza159@gmail.com", "Olejoint");

            //создаем обьект сообщения отправителя/получателя
            using var message = new MailMessage(sender, recipient)
            {
                Subject = "Это тестовое сообщение",
                Body = "Проверка тестового сообщения. Просьба не отвечать на него!",
            };

            //Создадим клиента-отправителя для общения с почтовым сервером по протоколу SMTP
            using (var client = new SmtpClient("smtp.yandex.ru", 587))
            {
                const string login = "sonziza@yandex.ru";
                const string password = "22Ks__Ol02";

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
            // то мы увидим на консоли соответствующую надпись.
            // При указании неверного адреса сервера/порта,
            // получим ошибку таймаута
            // Если мы ввели неверные учётные данные, или забыли их указать
            // то получим ошибку протокола подключения к серверу
            Console.WriteLine("Почта отправлена");
            Console.ReadLine();
        }
    }
}
