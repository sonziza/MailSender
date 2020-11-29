using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using MailSender.lib.Interfaces;

namespace MailSender.Services
{
    public class DebugMailService : IMailService
    {
        public IMailSender GetSender(
        string Address, int Port, bool UseSSL,
        string Password) =>
        new DebugMailSender(Address, Port, UseSSL, Password);
        
    }
    public class DebugMailSender : IMailSender
    {
        private readonly string _Address;
        private readonly int _Port;
        private readonly bool _UseSsl;
        private readonly string _Password;
        public DebugMailSender(
        string Address, int Port, bool UseSsl,
        string Password)
        {
            _Address = Address;
            _Port = Port;
            _UseSsl = UseSsl;
            _Password = Password;
        }
        public void Send(string From, string To, string Title, string Message)
        {
            Debug.WriteLine(
            "Почтовый сервер {0}:{1}(ssl:{2})[pass:{3}]",
            _Address, _Port, _UseSsl, _Password);
            Debug.WriteLine("Отправка письма от:{0} к:{1}\r\n\t{2}\r\n{3}",
            From, To, Title, Message);
        }
    }
}
