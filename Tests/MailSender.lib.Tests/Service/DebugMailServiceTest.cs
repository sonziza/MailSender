using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MailSender.lib;
using MailSender.lib.Service;
using System.Diagnostics;
using System.Text;
using static MailSender.Services.DebugMailService;

namespace MailSender.lib.Tests.Service
{
    [TestClass]
    public class DebugMailServiceTest
    {
        /// <summary>
        /// AAA (A-Arrange, A-Act, A-Assert)
        /// </summary>
        [TestMethod]
        public void Send_AddressINVALID()
        {
            #region A-Arrange

            string _Address = "ziza@yandex.ru";
            int _Port = 25;
            bool _UseSsl = false;
            string _Login = "oleg";
            string _Password = "22Ks__Ol02";

            DebugMailSender MailSender = new DebugMailSender(
                _Address,
                _Port,
                _UseSsl,
                _Login, 
                _Password
                );


            string From = "";
            string To = "";
            string Title = "";
            string Message = "";
            #endregion

            #region A - Act
            Debug.WriteLine(
                "Почтовый сервер {0}:{1}(ssl:{2})[login:{3} - pass:{4}]",
                _Address, _Port, _UseSsl, _Login, _Password);
            Debug.WriteLine("Отправка письма от:{0} к:{1}\r\n\t{2}\r\n{3}",
            From, To, Title, Message);
            #endregion



        }
    }
}
