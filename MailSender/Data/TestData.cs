using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSender.Data
{
	public static class TestData
	{
		public static List<Sender> Senders { get; } = Enumerable.Range(1, 5) //IEnumerable<int>
			.Select(i => new Sender
			{
				Name = $"Отправитель {i}",
				Address = $"sender_{i}@server.ru"
			})
			.ToList();

		public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 5)
			.Select(i => new Recipient
			{
				Name = $"Получатель {i}",
				Address = $"recipient{i}.server.ru",
			})
			.ToList();
		public static List<Server> Servers { get; } = Enumerable.Range(1, 5)
			.Select(i => new Server
			{
				Address = $"smtp.server{i}.com",
				Login = $"login{i}",
				Password = $"password{i}",
				UseSSL = i%2==0,
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
