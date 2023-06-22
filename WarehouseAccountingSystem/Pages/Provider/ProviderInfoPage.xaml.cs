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
using WarehouseAccountingSystem.Classes;
using WarehouseAccountingSystem.Models;

namespace WarehouseAccountingSystem.Pages.Provider
{
    /// <summary>
    /// Логика взаимодействия для ProviderInfoPage.xaml
    /// </summary>
    public partial class ProviderInfoPage : Page
    {
        public ProviderInfoPage(Models.Provider provider)
        {
            InitializeComponent();
            #region Наполнение элементов управления информацией из базы данных
            TxbAddress.Text = provider.Address;
            TxbINNNumber.Text = provider.INN.Number;
            TxbINNRegistrationDate.Text = provider.INN.RegistrationDate.ToShortDateString();
            TxbINNWhoRegistered.Text = provider.INN.WhoRegistered;
            TxbName.Text = "[" + provider.Name + "]";
            TxbPhoneNumber.Text = provider.PhoneNumber;
            #endregion
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }
    }
}
