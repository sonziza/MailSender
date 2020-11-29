namespace MailSender.lib.Interfaces
{
    /// <summary>
    ///  интерфейс сервиса отправки почты IMailService и интерфейс рассыльщика почты
    /// </summary>
    public interface IMailService
    {
        IMailSender GetSender(string Server, int Port, bool SSL,  string Password);
    }

    public interface IMailSender
    {
        void Send(string SenderAddress, string RecipientAddress, string Subject, string Body);
    }
}
