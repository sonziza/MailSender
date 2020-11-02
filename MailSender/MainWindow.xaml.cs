using MailSender.Models;
using System.Windows;
using MailSender.lib;
using System.Net.Mail;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnToPlanner_Click(object Sender, RoutedEventArgs e)
        {
            tabList.SelectedItem = tbPlanner;
        }

        private void RecipientsView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
