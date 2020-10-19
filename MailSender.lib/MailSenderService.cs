﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MailSender.lib
{
    class MailSenderService
    {
        public string ServerAddress { get; set; }

        public int ServerPort { get; set; }

        public bool UseSSL { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public void SendMessage(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            var from = new MailAddress(SenderAddress, "Oleg");
            var to = new MailAddress(RecipientAddress, "Olejoint");

            using (var message = new MailMessage(from, to))
            {

                message.Subject = Subject;
                message.Body = Body;

                using (var client = new SmtpClient(ServerAddress, ServerPort))
                {
                    client.EnableSsl = UseSSL;

                    client.Credentials = new NetworkCredential
                    {
                        UserName = Login,
                        Password = Password
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
