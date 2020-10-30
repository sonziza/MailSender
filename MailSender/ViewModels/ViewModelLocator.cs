using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.ViewModels
{
    /// <summary>
    /// Предназначен для того, чтобы из любой точки разметки можно достать любой ViewModel
    /// </summary>
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowView => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
