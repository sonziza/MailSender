using System;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        #region SendMessagesCount : int - Число отправленных сообщений

        /// <summary>Число отправленных сообщений</summary>
        private int _SentMessagesCount;

        /// <summary>Число отправленных сообщений</summary>
        public int SentMessagesCount { 
            get => _SentMessagesCount; 
            private set => Set(ref _SentMessagesCount, value);
        }

        #endregion

        #region _LastDataAppLaunch - последняя дата/время запуска приложения
        private DateTime  _LastLaunch;

        /// <summary>Последнее время запуска</summary>
        public DateTime LastLaunch
        {
            get => _LastLaunch;
            private set => Set(ref _LastLaunch, value);
        }
        #endregion
        public void MessageSent() => SentMessagesCount++;
        public void LastDateAppLaunch() => LastLaunch = DateTime.Now;
    }
}
