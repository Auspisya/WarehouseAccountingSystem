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

namespace WarehouseAccountingSystem.Pages.Product
{
    /// <summary>
    /// Логика взаимодействия для ProductInfoPage.xaml
    /// </summary>
    public partial class ProductInfoPage : Page
    {
        public ProductInfoPage(Models.Product product)
        {
            InitializeComponent();
            #region Наполнение элементов управления информацией из базы данных
            if (product.Description == null)
            {
                TxbDescription.Text = "Без описания";
            }
            else
            { 
                TxbDescription.Text = product.Description;
            }
            if (product.ExpirationDate == null)
            {
                TxbExpirationDate.Text = "Без срока годности";
            }
            else 
            {
                TxbExpirationDate.Text = product.ExpirationDate.ToShortDateString();
            }
            if (product.ManufactureDate == null)
            {
                TxbManufactureDate.Text = "Дата производства не указана";
            }
            else
            {
                TxbManufactureDate.Text = product.ManufactureDate.ToShortDateString();
            }
            TxbManufacturer.Text = product.Manufacturer;
            TxbName.Text = "[" + product.Name + "]";
            TxbProductClass.Text = product.ProductClass.Name;
            TxbProductGroup.Text = product.ProductGroup.Name;
            TxbQuantity.Text = product.Quantity.ToString();
            if (product.Unit.Description == null)
            {
                TxbUnit.Text = product.Unit.Name;
            }
            else
            {
                TxbUnit.Text = product.Unit.Name + " (" + product.Unit.Description + ")";
            }
            TxbManufacturerCountry.Text = product.ManufacturerCountry;
            #endregion
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }
    }
}
