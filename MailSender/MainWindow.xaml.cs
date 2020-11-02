using MailSender.Models;
using System.Windows;
using MailSender.lib;
using System.Net.Mail;
using System.Windows.Controls;

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

        private void Grid_Error(object sender, System.Windows.Controls.ValidationErrorEventArgs e)
        {
            var control = (Control)e.OriginalSource;
            //Added - если ошибка ПРОИЗОШЛА
            if (e.Action == ValidationErrorEventAction.Added)
            {
                control.ToolTip = e.Error.ErrorContent.ToString();
            }
            else
            {
                control.ToolTip = "";
            }
        }
    }
}
