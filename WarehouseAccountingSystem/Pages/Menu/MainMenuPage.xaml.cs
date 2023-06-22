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
using WarehouseAccountingSystem.Pages.Product;
using WarehouseAccountingSystem.Pages.ProductArrival;
using WarehouseAccountingSystem.Pages.ProductConsumption;

namespace WarehouseAccountingSystem.Pages.Menu
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void BtnProductPage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ProductPage());
        }

        private void BtnProductArrivalPage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ProductArrivalPage());
        }

        private void BtnProductConsumptionPage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new ProductConsumptionPage());
        }
    }
}
