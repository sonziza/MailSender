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
    /// Логика взаимодействия для SenderEditDialog.xaml
    /// </summary>
    public partial class SenderEditDialog : Window
    {
        public SenderEditDialog()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик события кнопки
        /// Если кнопка IsCancel == true, то результатом диалога будет false
        /// </summary>
        private void OnButtonClick(object _Sender, RoutedEventArgs E)
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
        ref string Address, ref string Name, ref string Password)
        {
            // Создаём окно и инициализируем его свойства
            var window = new SenderEditDialog
            {
                Title = Title,
                // Так можно инициализировать свойства вложенных объектов
                SenderAddress = { Text = Address },
                SenderName = { Text = Name },
                SenderPass = { Password = Password },
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
            Address = window.SenderAddress.Text;
            Name = window.SenderName.Text;
            Password = window.SenderPass.Password;
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
        out string Name,
        out string Password)
        {
            // Инициализируем переменные значениями на случай отмены операции
            Address = null;
            Name = null;
            Password = null;
            return ShowDialog("Создать отправителя",
            ref Address,
            ref Name,
            ref Password);
        }
    }
}
