using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для ServerEditDialog.xaml
    /// </summary>
    public partial class ServerEditDialog : Window
    {
        public ServerEditDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события ввода текста
        /// Блокирует ввод нечисловых данных
        /// </summary>
        private void OnPortTextInput(object Sender, TextCompositionEventArgs E)
        {
            // Если источник события - не текстовое поле ввода
            // или текст в поле ввода отсутствует, то...
            // ничего не делаем
            if (!(Sender is TextBox text_box) || text_box.Text == "") return;
            // иначе если не удалось превратить текст в число, то
            // отмечаем событие как обработанное - текст не введётся
            E.Handled = !int.TryParse(text_box.Text, out _);
        }
        /// <summary>
        /// Обработчик события кнопки
        /// Если кнопка IsCancel == true, то результатом диалога будет false
        /// </summary>
        private void OnButtonClick(object Sender, RoutedEventArgs E)
        {
            DialogResult = !((Button)E.OriginalSource).IsCancel;
            Close();
        }
        // Добавляем статические методы для удобства работы с диалогом

        /// <summary>
        /// Метод, позволяющий отобразить диалог для редактирования данных
        /// Редактируемые параметры передаются по ссылке
        /// Если пользователь выбрал Ok, то метод возвращает true
        /// Если пользователь выбрал Cancel, то параметры не меняются.
        /// </summary>
        public static bool ShowDialog(
        string Title,
        ref string Address, ref int Port, ref bool UseSSL)
        {
            // Создаём окно и инициализируем его свойства
            var window = new ServerEditDialog
            {
                Title = Title,
                // Так можно инициализировать свойства вложенных объектов
                ServerAddress = { Text = Address },
                ServerPort = { Text = Port.ToString() },
                ServerSSL = { IsChecked = UseSSL },
                // Берём класс "Приложение"
                Owner = Application
            // получаем экземпляр текущего приложения
            .Current
            // берём все окна приложения
            .Windows
            // пеерводим их из интерфейса IEnumerable в IEnumerable<Window>
            .Cast<Window>()
            // находим первое окно, у которого свойство IsActive == true
            .FirstOrDefault(window => window.IsActive)
            };
            if (window.ShowDialog() != true) return false;
            Address = window.ServerAddress.Text;
            Port = int.Parse(window.ServerPort.Text);
            return true;
        }

        /// <summary>
        /// Метод, позволяющий отобразить диалог создания нового сервера
        /// Редактируемые параметры передаются по ссылке
        /// Если пользователь выбрал Ok, то метод возвращает true
        /// Если пользователь выбрал Cancel, то возвращаются дефолтные значения
        /// </summary>
        public static bool Create(
        out string Address,
        out int Port,
        out bool UseSSL,
        out string Description)
        {
            // Инициализируем переменные значениями на случай отмены операции
            Address = null;
            Port = 25;
            UseSSL = false;
            Description = null;
            return ShowDialog("Создать сервер",
            ref Address,
            ref Port,
            ref UseSSL);
        }
    }
}
