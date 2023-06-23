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
using System.Xml.Linq;
using WarehouseAccountingSystem.Classes;
using WarehouseAccountingSystem.Models;

namespace WarehouseAccountingSystem.Pages.Provider
{
    /// <summary>
    /// Логика взаимодействия для ProviderAddPage.xaml
    /// </summary>
    public partial class ProviderAddPage : Page
    {
        public ProviderAddPage()
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
            if (TxbProviderAddress.Text == "" || TxbProviderINNNumber.Text == "" || TxbProviderINNWhoRegistered.Text == "" ||
                TxbProviderName.Text == "" || TxbProviderPhoneNumber.Text == "" || DPProviderINNRegistrationDate.Text == "")
            {
                MessageBox.Show("Нужно заполнить обязательные поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                            Number = TxbProviderINNNumber.Text,
                            WhoRegistered = TxbProviderINNWhoRegistered.Text,
                            RegistrationDate = DateTime.Parse(DPProviderINNRegistrationDate.Text)
                        };

                        Models.Provider provider = new Models.Provider()
                        {
                            INNId = inn.Id,
                            Address = TxbProviderAddress.Text,
                            Name = TxbProviderName.Text,
                            PhoneNumber = TxbProviderPhoneNumber.Text
                        };
                        DBConnection.DBConnect.INN.Add(inn);
                        DBConnection.DBConnect.Provider.Add(provider);
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
