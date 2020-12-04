using System;
using System.Linq;
using MailSender.lib.Models;
using System.Collections.Generic;
using MailSender.lib.Service;

namespace MailSender.Data
{
	static class TestData
	{
		public static List<MessageSent> MessageSents { get; } = Enumerable.Range(1, 5)
			.Select(i => new MessageSent
			{
				AddresFrom = $"Отправитель{i}",
				AssressTo = $"Получатель{i}",
				DateTimeSent = DateTime.Now,
				MessageBody = $"Сообщение {i}",
				MessageSubject = $"Тело сообщения{i}"
			}
				).ToList();
		public static List<Sender> Senders { get; } = Enumerable.Range(1, 5) //IEnumerable<int>
			.Select(i => new Sender
			{
				Name = $"Отправитель {i}",
				Address = $"sender_{i}@server.ru",
				Password = TextEncoder.Encode($"Password-{i}")
			})
			.ToList();

		public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 5)
			.Select(i => new Recipient
			{
				Name = $"Получатель {i}",
				Address = $"recipient_{i}@mail.ru",
			})
			.ToList();
		public static List<Server> Servers { get; } = Enumerable.Range(1, 5)
			.Select(i => new Server
			{
				Name = $"Name {i}",
				Address = $"smtp.server{i}.com",
				UseSSL = i%2==0,
				Description = $"Description{i}",
			})
			.ToList();
		public static List<Message> Messages { get; } = Enumerable.Range(1, 5)
			.Select(i => new Message
			{
				Subject = $"Сообщение{i}",
				Body = $"Тело сообщения {i}",
			})
			.ToList();
	}
}
