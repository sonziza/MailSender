using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using MailSender.lib.Interfaces;

namespace MailSender.lib.Service
{
    public class SmtpMailService : IMailService
    {
        public SmtpMailService()
        {

        }
        /// <summary>
        ///  фабрика, которая будет создавать нужные объекты - параметры отправки почты
        /// </summary>
        /// <returns></returns>
        public IMailSender GetSender(string Server, int Port, bool SSL, string Password)
        {
            return new SmtpMailSender(Server, Port, SSL, Password);
        }
    }

    internal class SmtpMailSender : IMailSender
    {
        private readonly string _Address;
        private readonly int _Port;
        private readonly bool _Ssl;
        private readonly string _Password;

        public SmtpMailSender(string Address, int Port, bool SSL, string Password)
        {
            _Address = Address;
            _Port = Port;
            _Ssl = SSL;
            _Password = Password;
        }

        public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            var from = new MailAddress(SenderAddress);
            var to = new MailAddress(RecipientAddress);

            using (var message = new MailMessage(from, to))
            {

                message.Subject = Subject;
                message.Body = Body;

                using (var client = new SmtpClient(_Address, _Port))
                {
                    client.EnableSsl = _Ssl;

                    client.Credentials = new NetworkCredential
                    {                        
                        UserName = SenderAddress,
                        Password = _Password
                    };

                    try
                    {
                        client.Send(message);
                    }
                    catch (SmtpException e)
                    {
                        Trace.TraceError(e.ToString());
                        throw;
                    }
                }
            }
        }
    }
}
