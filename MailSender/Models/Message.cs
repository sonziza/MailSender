using System.ComponentModel;
using MailSender.Models.Base;

namespace MailSender.Models
{
    public class Message: Entity, IDataErrorInfo
    {

        public string Subject { get; set; }

        public string Body { get; set; }

        public string Error => throw new System.NotImplementedException();
        public string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    default: return null;
                    case "Subject":
                        if (Subject == "") return "Пустое значение!";
                        if (Subject.Length > 255) return "Вы ввели слишком большой текст!";
                        return null;
                    case "Body":
                        if (Body == "") return "Пустое значение!";
                        if (Body.Length > 500) return $"Вы ввели слишком больше 500 символов({Body.Length})";
                        return null;
                }
            }
        }
    }
}
