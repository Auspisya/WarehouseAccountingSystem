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
using WarehouseAccountingSystem.Pages.Product;

namespace WarehouseAccountingSystem.Pages.Provider
{
    /// <summary>
    /// Логика взаимодействия для ProviderPage.xaml
    /// </summary>
    public partial class ProviderPage : Page
    {
        public ProviderPage()
        {
            InitializeComponent();
            DGProvider.ItemsSource = null;
            DGProvider.ItemsSource = DBConnection.DBConnect.Provider.ToList();
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
                    var itemsList = DBConnection.DBConnect.Provider.ToList();
                    var searchResults = itemsList.Where(item => item.Name.ToLower().Contains(searchString)).ToList();
                    DGProvider.ItemsSource = searchResults.ToList();
                }
                else
                {
                    DGProvider.ItemsSource = DBConnection.DBConnect.Provider.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ProviderAddPage());
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DGProvider.ItemsSource = null;
            DGProvider.ItemsSource = DBConnection.DBConnect.Provider.ToList();
        }

        private void BtnShowInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ProviderInfoPage((sender as Button).DataContext as Models.Provider));
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
