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

namespace HW10Task
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Manager acc;
        Manager selectedAcc;
        List<Manager> accounts;
        bool flag;

        public MainWindow()
        {
            acc = new Manager();
            accounts = acc.Read();
            InitializeComponent();
            ListView.ItemsSource = accounts;
            ComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Кнопка для изменения данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (selectedAcc=null)
        }


        /// <summary>
        /// Добавление нового аккуанта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (BoxAdd1.Text != "" && BoxAdd2.Text != "" && BoxAdd3.Text != "" && BoxAdd4.Text != "" && BoxAdd5.Text != "")
            {
                Manager accAdd = new Manager(accounts.Count, BoxAdd1.Text, BoxAdd2.Text, BoxAdd3.Text, BoxAdd4.Text, BoxAdd5.Text);
                accounts.Add(accAdd);
                accAdd.Write(accounts);
                ListView.Items.Refresh();
                BoxAdd1.Clear();
                BoxAdd2.Clear();
                BoxAdd3.Clear();
                BoxAdd4.Clear();
                BoxAdd5.Clear();
            }
            else MessageBox.Show("Не все данные заполнены");
        }

        private void rbPassport_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void rbPassport_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonSort_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
