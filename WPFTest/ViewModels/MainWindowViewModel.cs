using System;
using System.Collections.Generic;
using System.Text;
using WPFTest.ViewModels.Base;

namespace WPFTest.ViewModels
{
    class MainWindowViewModel:ViewModel
    {
        private string _Title = "Главное окно программы";
        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

    }
}
