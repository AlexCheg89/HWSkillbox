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

namespace HW9Task
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Разделение по словам
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string[] StringToWord(string text)
        {
            string[] words = text.Split(' ');

            return words;
        }

        /// <summary>
        /// Изменение порядка слов
        /// </summary>
        /// <param name="text"></param>
        static string[] RewersWords (string text) 
        {
            string[] new_text = StringToWord(text);

            string[] revers_text = null;

            for (int i = new_text.Length -1;  i >= 0; i--)
            {
                revers_text[i] = new_text[i];
                //Console.Write($"{new_text[i]} ");
            }
            return revers_text;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStringToWord_Click(object sender, RoutedEventArgs e)
        {
            var enteringString = StringToWord(textEnter.ToString());

            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
