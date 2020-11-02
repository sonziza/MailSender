using MailSender.Models.Base;
using System;
using System.ComponentModel;

namespace MailSender.Models
{
    public class Recipient : Person, IDataErrorInfo {

        public override string Name {
            get { return base.Name; }
            set
            {
                //if (value is null)
                //{
                //    throw new ArgumentNullException(nameof(value));
                //}
                ////if (value == "QWE") throw new ArgumentException("Запрещено вводить QWE!!!", nameof(value));
                //if (value == "") throw new ArgumentException("Запрещено вводить пустые строки");

                base.Name = value;
            }
        }

        string IDataErrorInfo.Error {get;} = null;
        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    default: return null;

                    case "Name":
                        if ((Name == "QWE") || (Name == "qwe"))
                            return  "запрещённая комбинация qwe!";
                        return null;
                    case "Address":
                        if (Address == "") return "адрес не может быть пустым!";
                        return null;
                }
            }
        }
    }
}
