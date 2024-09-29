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
            if (selectedAcc == null) MessageBox.Show("Выбирите аккуант для измения его данных");
            else
            {
                string newValue = TextBox.Text;
                if (ComboBox.SelectedIndex == 0)
                {
                    if (newValue != "")
                    {
                        selectedAcc = (acc.Changing(newValue, selectedAcc as Account, 4)) as Manager;
                    }
                    else MessageBox.Show("введите данные");
                }
                else
                {
                    var rbCheck = GetCheckedRadio(MyElement);
                    switch (rbCheck)
                    {
                        case "rbSurname":
                            selectedAcc = acc.Changing(newValue, selectedAcc, 0);
                            break;
                        case "rbFirstName":
                            selectedAcc = acc.Changing(newValue, selectedAcc, 1);
                            break;
                        case "rbPatronymic":
                            selectedAcc = acc.Changing(newValue, selectedAcc, 2);
                            break;
                        case "rbPhoneNumber":
                            if (newValue != "")
                            {
                                selectedAcc = acc.Changing(newValue, selectedAcc, 3);
                            }
                            else MessageBox.Show("введите данные");
                            break;
                        case "rbPassport":
                            selectedAcc = acc.Changing(newValue, selectedAcc, 4);
                            break;                           
                    }

                    accounts[selectedAcc.Id] = selectedAcc;
                    flag = true;
                    UpdateRBInfo();
                    ListView.Items.Refresh();
                    flag = false;
                    acc.Write(accounts);
                    UpdateChangeInfo();
                }
            }
        }

        /// <summary>
        /// Проверка какой RadioButton выбран
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private string GetCheckedRadio(UIElement container)
        {
            foreach (var control in LogicalTreeHelper.GetChildren(container))
            {
                RadioButton radio = control as RadioButton;

                if (radio != null && radio.IsChecked == true)
                {
                    return radio.Name;
                }
            }

            return null;
        }

        /// <summary>
        /// Обновление информации в RadioButton
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void UpdateRBInfo()
        {
            rbSurname.Content = selectedAcc.Surname;
            rbFirstName.Content = selectedAcc.FirstName;
            rbPatronymic.Content = selectedAcc.Patronymic;
            rbPhoneNumber.Content = selectedAcc.PhoneNumber;
            rbPassport.Content = selectedAcc.Passport;
        }

        /// <summary>
        /// Вывод информации о внесенных изменниях
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void UpdateChangeInfo()
        {
            if (selectedAcc.TimeDataChange == acc.DefaultDate)
            {
                txt1.Text = null;
                txt2.Text = null;
                txt3.Text = null;
                txt4.Text = null;
            }
            else
            {
                txt1.Text = selectedAcc.TimeDataChange.ToString();
                txt2.Text = selectedAcc.Changes;
                txt3.Text = selectedAcc.TypeChange;
                txt4.Text= selectedAcc.WhoChange;
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!flag)
            {
                selectedAcc = (Manager)ListView.SelectedItem;
            }
            if (selectedAcc == !null)
            {
                Text
            }
        }

        /// <summary>
        /// Отображение данных паспорта когда менеджер хочет его изменить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbPassport_Checked(object sender, RoutedEventArgs e)
        {
            if (ComboBox.SelectedIndex !=0)
            {
                TextBox.Text = selectedAcc.GetPassportInf();
            }
        }
        
        /// <summary>
        /// Удаленние данных паспорта из TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbPassport_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBox.Clear();
        }
        
        /// <summary>
        /// Выбор Консультанта и менеджера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox.Clear();

            if(ComboBox.SelectedItem != null)
            {
                if (ComboBox.SelectedIndex == 0)
                {
                    ButtonAdd.IsEnabled = false;
                    BoxAdd1.IsEnabled = false;
                    BoxAdd2.IsEnabled = false;
                    BoxAdd3.IsEnabled = false;
                    BoxAdd4.IsEnabled = false;
                    BoxAdd5.IsEnabled = false;
                    rbSurname.IsEnabled = false;
                    rbFirstName.IsEnabled = false;
                    rbPatronymic.IsEnabled = false;
                    rbPassport.IsEnabled = false;
                    rbPhoneNumber.IsEnabled = true;
                }
                else
                {
                    ButtonAdd.IsEnabled = true;
                    BoxAdd1.IsEnabled = true;
                    BoxAdd2.IsEnabled = true;
                    BoxAdd3.IsEnabled = true;
                    BoxAdd4.IsEnabled = true;
                    BoxAdd5.IsEnabled = true;
                    rbSurname.IsEnabled = true;
                    rbFirstName.IsEnabled = true;
                    rbPatronymic.IsEnabled = true;
                    rbPassport.IsEnabled = true;
                }
            }
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

        /// <summary>
        /// Сортировка списка аккаунтов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSort_Click(object sender, RoutedEventArgs e)
        {
            accounts.Sort();
            ListView.Items.Refresh();
        }
    }
}
