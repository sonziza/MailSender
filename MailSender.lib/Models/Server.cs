﻿using MailSender.lib.Models.Base;
using System;

namespace MailSender.lib.Models
{
    public class Server:NamedEntity
    {
        public string Address { get; set; }

        private int _Port = 25;

        public int Port
        {
            get => _Port;
            set
            {
                if(value < 0 || value >= 65535)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Номер порта должен быть в диапазоне от 0 до 65534");
                _Port = value;
            }
        }

        public bool UseSSL { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Description { get; set; }
    }
}
