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

namespace WarehouseAccountingSystem.Pages.Receiver
{
    /// <summary>
    /// Логика взаимодействия для ReceiverInfoPage.xaml
    /// </summary>
    public partial class ReceiverInfoPage : Page
    {
        public ReceiverInfoPage(Models.Receiver receiver)
        {
            InitializeComponent();
            #region Наполнение элементов управления информацией из базы данных
            TxbAddress.Text = receiver.Address;
            TxbINNNumber.Text = receiver.INN.Number;
            TxbINNRegistrationDate.Text = receiver.INN.RegistrationDate.ToShortDateString();
            TxbINNWhoRegistered.Text = receiver.INN.WhoRegistered;
            TxbName.Text = "[" + receiver.Name + "]";
            TxbPhoneNumber.Text = receiver.PhoneNumber;
            #endregion
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }
    }
}
