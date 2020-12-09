using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using MailSender.lib.Models;
using MailSender.ViewModels.Base;
using OxyPlot;
using OxyPlot.Series;

namespace MailSender.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        Dictionary<DateTime, int> SentMessageGroups;


        #region SendMessagesCount : int - Число отправленных сообщений в момент работы приложения

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
        public StatisticViewModel()
        {
            SentMessageGroups = new Dictionary<DateTime, int>();
            //Прорисовка диаграммы
            //this.DiagramModel = new PlotModel { Title = "Отправленные сообщения по дням" };

            //this.DiagramModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "количество сообщений"));


            this.Points = new List<DataPoint>
            {
                new DataPoint(0, 4),
                new DataPoint(10, 13),
                new DataPoint(20, 15),
                new DataPoint(30, 16),
                new DataPoint(40, 12),
                new DataPoint(50, 12)
            };

        }
        public PlotModel DiagramModel { get; private set; }
        public IList<DataPoint> Points { get; private set; }

        public void GetMessagesInDay(ObservableCollection<SentMessage> SentMessages)
        {
            var res = SentMessages.GroupBy(sm => sm.DateTimeSent.Date)
                        .Select(g => new { Name = g.Key, Count = g.Count() })
                        .ToArray();
            foreach (var group in res)
                SentMessageGroups.Add(group.Name, group.Count);
            foreach (var group in SentMessageGroups)
                Debug.WriteLine($"{group.Key} : {group.Value}");
        }

    }
}
