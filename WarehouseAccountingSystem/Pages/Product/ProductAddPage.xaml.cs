using System;
using System.Collections.Generic;
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
using WarehouseAccountingSystem.Classes;
using WarehouseAccountingSystem.Models;

namespace WarehouseAccountingSystem.Pages.Product
{
    /// <summary>
    /// Логика взаимодействия для ProductAddPage.xaml
    /// </summary>
    public partial class ProductAddPage : Page
    {
        public ProductAddPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxbManufacturer.Text == null || TxbName.Text == null || TxbQuantity.Text == null ||
                CmbProductClass.Text == null || CmbProductGroup.Text == null || CmbUnit.Text == null ||
                DPExpirationDate.Text == null || DPManufactureDate.Text == null)
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
                        Models.Product product = new Models.Product
                        {
                            Description = TxbDescription.Text,
                            ExpirationDate = DateTime.Parse(DPExpirationDate.Text),
                            ManufactureDate = DateTime.Parse(DPManufactureDate.Text),
                            Manufacturer = TxbManufacturer.Text,
                            Name = TxbName.Text,
                            ProductClass = CmbProductClass.SelectedItem as ProductClass,
                            ProductGroup = CmbProductGroup.SelectedItem as ProductGroup,
                            Quantity = double.Parse(TxbQuantity.Text),
                            Unit = CmbUnit.SelectedItem as Unit
                        };
                        DBConnection.DBConnect.Product.Add(product);
                        DBConnection.DBConnect.SaveChanges();
                        MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Navigation.frameNav.GoBack();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(),
                            "Критическая ошибка",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void TxbNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }
    }
}
