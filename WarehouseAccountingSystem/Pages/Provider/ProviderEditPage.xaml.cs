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
    /// Логика взаимодействия для ProviderEditPage.xaml
    /// </summary>
    public partial class ProviderEditPage : Page
    {
        private int providerId;
        public ProviderEditPage(Models.Provider provider)
        {
            InitializeComponent();
            #region Наполнение элементов управления информацией из базы данных
            TxbProviderAddress.Text = provider.Address;
            TxbProviderINNNumber.Text = provider.INN.Number;
            TxbProviderINNWhoRegistered.Text = provider.INN.WhoRegistered;
            TxbProviderName.Text = provider.Name;
            TxbProviderPhoneNumber.Text = provider.PhoneNumber;
            DPProviderINNRegistrationDate.Text = provider.INN.RegistrationDate.ToShortDateString();
            #endregion
            providerId = provider.Id;
        }

        private void TxbNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TxbProviderAddress.Text == "" || TxbProviderINNNumber.Text == "" || TxbProviderINNWhoRegistered.Text == "" ||
                TxbProviderName.Text == "" || TxbProviderPhoneNumber.Text == "" || DPProviderINNRegistrationDate.Text == "")
            {
                MessageBox.Show("Нужно заполнить обязательные поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (MessageBox.Show("Вы точно хотите редактировать данные?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {

                }
                else
                {
                    try
                    {
                        menshakova_inventoryControlEntities context = new menshakova_inventoryControlEntities();
                        #region Берем значения из элементов управления и вносим их в базу данных
                        var provider = context.Provider.Where(item => item.Id == providerId).FirstOrDefault();
                        provider.Name = TxbProviderName.Text;
                        provider.PhoneNumber = TxbProviderPhoneNumber.Text;
                        provider.Address = TxbProviderAddress.Text;
                        provider.INN.Number = TxbProviderINNNumber.Text;
                        provider.INN.WhoRegistered = TxbProviderINNWhoRegistered.Text;
                        provider.INN.RegistrationDate = DateTime.Parse(DPProviderINNRegistrationDate.Text);
                        #endregion
                        context.SaveChanges();
                        MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }
    }
}
