using MailSender.lib.Interfaces;
using MailSender.lib.Service;
using MailSender.Services;
using MailSender.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost _Hosting;
        public static IHost Hosting => _Hosting ??= Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
            .ConfigureServices(ConfigureServices)
            .Build();
        //обеспечим доступ к контейнеру сервисов
        public static IServiceProvider Services => Hosting.Services;

        /// <summary>
        /// здесь хранятся все сервисы, которые понадобятся в нашем приложении
        /// </summary>
        /// <param name="host"></param>
        /// <param name="services">сервисы</param>
        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
#if DEBUG
            services.AddTransient<IMailService, DebugMailService>();
#else
            services.AddTransient<IMailService, SmtpMailService>();
#endif
        }
    }
}
