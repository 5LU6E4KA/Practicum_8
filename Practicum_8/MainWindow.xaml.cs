using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Practicum_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Point.IsChecked = true;
            Closing += WindowClosing;
        }

        private void StartCheckClick(object sender, RoutedEventArgs e)
        {
            Box.SpellCheck.IsEnabled = true;
        }

        private void StartClearClick(object sender, RoutedEventArgs e)
        {
            const string message = "Вы уверены, что желаете очистить запись?";
            const string caption = "Form cleaning";
            var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                Box.SpellCheck.IsEnabled = false;
                Box.Clear();
            }
        }

        private Dictionary<string, string> languages = new Dictionary<string, string> { { "Русский", "ru" }, { "Английский", "en" } };

        private void ClickLanguage(object sender, RoutedEventArgs e)
        {
            Box.Language = System.Windows.Markup.XmlLanguage.GetLanguage(languages[((RadioButton)sender).Content.ToString()]);
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            const string message = "Вы уверены, что хотите закрыть приложение?";
            const string caption = "Form closing";
            var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}