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

namespace WarehouseAccountingSystem.Pages.ProductConsumption
{
    /// <summary>
    /// Логика взаимодействия для ProductConsumptionPage.xaml
    /// </summary>
    public partial class ProductConsumptionPage : Page
    {
        public ProductConsumptionPage()
        {
            InitializeComponent();
            DGProductConsumption.ItemsSource = null;
            DGProductConsumption.ItemsSource = DBConnection.DBConnect.ProductConsumption.ToList();
        }

        private void BtnShowInfo_Click(object sender, RoutedEventArgs e)
        {

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
                    var itemsList = DBConnection.DBConnect.ProductConsumption.ToList();
                    var searchResults = itemsList.Where(item => item.Product.Name.ToLower().Contains(searchString)).ToList();
                    DGProductConsumption.ItemsSource = searchResults.ToList();
                }
                else
                {
                    DGProductConsumption.ItemsSource = DBConnection.DBConnect.ProductConsumption.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DGProductConsumption.ItemsSource = null;
            DGProductConsumption.ItemsSource = DBConnection.DBConnect.ProductConsumption.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ProductConsumptionAddPage());
        }
    }
}
