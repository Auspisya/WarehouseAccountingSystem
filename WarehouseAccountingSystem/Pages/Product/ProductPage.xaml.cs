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

namespace WarehouseAccountingSystem.Pages.Product
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            DGProduct.ItemsSource = null;
            DGProduct.ItemsSource = DBConnection.DBConnect.Product.ToList();
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

                    var itemsList = DBConnection.DBConnect.Product.ToList();

                    //Ищем совпадения в таблице по фамилии
                    var searchResults = itemsList.Where(item => item.Name.ToLower().Contains(searchString)).ToList();

                    //Заполняем таблицу записями, где есть совпадения
                    DGProduct.ItemsSource = searchResults.ToList();
                }
                else
                {
                    DGProduct.ItemsSource = DBConnection.DBConnect.Product.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DGProduct.ItemsSource = null;
            DGProduct.ItemsSource = DBConnection.DBConnect.Product.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ProductAddPage());
        }

        private void BtnShowInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ProductInfoPage((sender as Button).DataContext as Models.Product));
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ProductEditPage((sender as Button).DataContext as Models.Product));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
