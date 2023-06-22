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

namespace WarehouseAccountingSystem.Pages.ProductArrival
{
    /// <summary>
    /// Логика взаимодействия для ProductArrivalPage.xaml
    /// </summary>
    public partial class ProductArrivalPage : Page
    {
        public ProductArrivalPage()
        {
            InitializeComponent();
            DGProductArrival.ItemsSource = null;
            DGProductArrival.ItemsSource = DBConnection.DBConnect.ProductArrival.ToList();
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
                    var itemsList = DBConnection.DBConnect.ProductArrival.ToList();
                    var searchResults = itemsList.Where(item => item.Product.Name.ToLower().Contains(searchString)).ToList();
                    DGProductArrival.ItemsSource = searchResults.ToList();
                }
                else
                {
                    DGProductArrival.ItemsSource = DBConnection.DBConnect.ProductArrival.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ProductArrivalAddPage());
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DGProductArrival.ItemsSource = null;
            DGProductArrival.ItemsSource = DBConnection.DBConnect.ProductArrival.ToList();
        }

        private void BtnShowInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ProductArrivalInfoPage((sender as Button).DataContext as Models.ProductArrival));
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
