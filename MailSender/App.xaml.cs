using MailSender.lib.Interfaces;
using MailSender.lib.Service;
using MailSender.Services;
using MailSender.Data;
using MailSender.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;

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
            .ConfigureAppConfiguration(config => config
            .AddJsonFile("appconfig.json", true)
            )
            .ConfigureLogging(log => log
            .AddConsole()
            .AddDebug()
            )
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
            var connection_str = host.Configuration.GetConnectionString("Default");

            services.AddDbContext<MailSenderDBContext>(opt => opt
               .UseSqlServer(host.Configuration.GetConnectionString("Default")));
            services.AddTransient<MailSenderDBInitializer>();
            services.AddTransient<MailSenderDBContextInitializer>();
        }
        /// <summary>
        /// Инициализация сервисов как только запускается приложение
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            Services.GetRequiredService<MailSenderDBInitializer>().Initialize();
            base.OnStartup(e);
        }

    }

}
