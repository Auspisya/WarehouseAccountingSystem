using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WarehouseAccountingSystem.Classes;
using WarehouseAccountingSystem.Models;

namespace WarehouseAccountingSystem.Pages.Receiver
{
    /// <summary>
    /// Логика взаимодействия для ReceiverAddPage.xaml
    /// </summary>
    public partial class ReceiverAddPage : Page
    {
        public ReceiverAddPage()
        {
            InitializeComponent();
        }

        private void TxbNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxbAddress.Text == "" || TxbINNNumber.Text == "" || TxbINNWhoRegistered.Text == "" ||
                TxbName.Text == "" || TxbPhoneNumber.Text == "" || DPINNRegistrationDate.Text == "")
            {
                MessageBox.Show("Нужно заполнить обязательные поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (TxbINNNumber.Text.Length < 12)
                {
                    MessageBox.Show("ИНН не может быть меньше 12 символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (TxbPhoneNumber.Text.Length < 12)
                {
                    MessageBox.Show("Номер телефона не может быть меньше 12 символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    if (MessageBox.Show("Вы точно хотите добавить данные?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        try
                        {
                            INN inn = new INN()
                            {
                                Number = TxbINNNumber.Text,
                                WhoRegistered = TxbINNWhoRegistered.Text,
                                RegistrationDate = DateTime.Parse(DPINNRegistrationDate.Text)
                            };

                            Models.Receiver receiver = new Models.Receiver()
                            {
                                INNId = inn.Id,
                                Address = TxbAddress.Text,
                                Name = TxbName.Text,
                                PhoneNumber = TxbPhoneNumber.Text
                            };
                            DBConnection.DBConnect.INN.Add(inn);
                            DBConnection.DBConnect.Receiver.Add(receiver);
                            DBConnection.DBConnect.SaveChanges();
                            MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Navigation.frameNav.GoBack();
                        }
                        catch (DbEntityValidationException ex)
                        {
                            foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                            {
                                MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                                foreach (DbValidationError err in validationError.ValidationErrors)
                                {
                                    MessageBox.Show(err.ErrorMessage + "");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
