using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using MailSender.lib.Models;
using MailSender.ViewModels.Base;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MailSender.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        //Словарь отправленных сообщений за день
        private Dictionary<DateTime, int> SentMessageGroups { get; set; } = new Dictionary<DateTime, int>();
        //Диаграмма
        public PlotModel DiagramModel { get; private set; } = new PlotModel();
        //Список точек
        public IList<DataPoint> Points { get; private set; } = new List<DataPoint>();


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
        public StatisticViewModel()
        {

            
        }

        public void GetMessagesInDay(ObservableCollection<SentMessage> SentMessages)
        {
            var res = SentMessages.GroupBy(sm => sm.DateTimeSent.Date)
                        .Select(g => new { Name = g.Key, Count = g.Count() })
                        .ToArray();

            foreach (var group in res)
                SentMessageGroups.Add(group.Name, group.Count);
        }
        /// <summary>
        /// Прорисовка диаграммы и нанесение точек
        /// </summary>
        public void DrawDiagram()
        {
            #region черновик прорисовки
            //Прорисовка диаграммы
            //this.DiagramModel = new PlotModel { Title = "Отправленные сообщения по дням" };

            //this.DiagramModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "количество сообщений"));


            //this.Points = new List<DataPoint>
            //{
            //    new DataPoint(0, 4),
            //    new DataPoint(10, 13),
            //    new DataPoint(20, 15),
            //    new DataPoint(30, 16),
            //    new DataPoint(40, 12),
            //    new DataPoint(50, 12)
            //};
            //this.Points.Add(new DataPoint(DateTimeAxis.ToDouble(myDateTime), myValue));
            #endregion

            //добавление точек
            foreach (var group in SentMessageGroups)
            {
                var groupDate = DateTimeAxis.ToDouble(group.Key);
                Points.Add(new DataPoint(groupDate, group.Value));
            };

            


            //Прорисовка диаграммы
            DiagramModel.Title = "Статистика исходящих писем";
            var startDate = DateTime.Now.AddDays(-10);
            var endDate = DateTime.Now;
            var minValue = DateTimeAxis.ToDouble(startDate);
            var maxValue = DateTimeAxis.ToDouble(endDate);
            //Добавление осей диаграммы
            DiagramModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = minValue,
                Maximum = maxValue,
                StringFormat = "M/d"
            });
            DiagramModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = 30,
                StartPosition = 0,
            });
        }
        public void MessageSent() => SentMessagesCount++;
        public void LastDateAppLaunch() => LastLaunch = DateTime.Now;

    }
}
