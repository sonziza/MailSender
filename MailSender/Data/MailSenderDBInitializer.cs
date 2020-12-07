﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSender.Data
{
    class MailSenderDBInitializer
    {
        private readonly MailSenderDBContext _db;

        public MailSenderDBInitializer(MailSenderDBContext db) => _db = db;

        public void Initialize()
        {
            _db.Database.Migrate();

            InitializeRecipients();
            InitializeSenders();
            InitializeServers();
            InitializeMessages();
            InitializeSentMessages();
        }

        private void InitializeRecipients()
        {
            if (_db.Recipients.Any()) return;

            _db.Recipients.AddRange(TestData.Recipients);
            _db.SaveChanges();
        }

        private void InitializeSenders()
        {
            if (_db.Senders.Any()) return;

            _db.Senders.AddRange(TestData.Senders);
            _db.SaveChanges();
        }

        private void InitializeMessages()
        {
            if (_db.Messages.Any()) return;

            _db.Messages.AddRange(TestData.Messages);
            _db.SaveChanges();
        }

        private void InitializeServers()
        {
            if (_db.Servers.Any()) return;

            _db.Servers.AddRange(TestData.Servers);
            _db.SaveChanges();
        }
        private void InitializeSentMessages()
        {
            if (_db.SentMessages.Any()) return;

            _db.SentMessages.AddRange(TestData.SentMessages);
            _db.SaveChanges();
        }
    }
}
