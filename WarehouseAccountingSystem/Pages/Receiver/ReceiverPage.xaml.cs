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
using WarehouseAccountingSystem.Pages.Provider;

namespace WarehouseAccountingSystem.Pages.Receiver
{
    /// <summary>
    /// Логика взаимодействия для ReceiverPage.xaml
    /// </summary>
    public partial class ReceiverPage : Page
    {
        public ReceiverPage()
        {
            InitializeComponent();
            DGReceiver.ItemsSource = null;
            DGReceiver.ItemsSource = DBConnection.DBConnect.Receiver.ToList();
        }

        private void BtnShowInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ReceiverInfoPage((sender as Button).DataContext as Models.Receiver));
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ReceiverEditPage((sender as Button).DataContext as Models.Receiver));
        }

        private void TxbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TxbSearch.Text = "";
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbSearch.Text != "")
                {
                    string searchString = TxbSearch.Text.ToLower();
                    var itemsList = DBConnection.DBConnect.Receiver.ToList();
                    var searchResults = itemsList.Where(item => item.Name.ToLower().Contains(searchString)).ToList();
                    DGReceiver.ItemsSource = searchResults.ToList();
                }
                else
                {
                    DGReceiver.ItemsSource = DBConnection.DBConnect.Receiver.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DGReceiver.ItemsSource = null;
            DGReceiver.ItemsSource = DBConnection.DBConnect.Receiver.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ReceiverAddPage());
        }
    }
}
