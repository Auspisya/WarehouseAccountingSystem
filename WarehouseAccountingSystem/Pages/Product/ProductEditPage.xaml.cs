using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для ProductEditPage.xaml
    /// </summary>
    public partial class ProductEditPage : Page
    {
        private int productId;
        public ProductEditPage(Models.Product product)
        {
            InitializeComponent();
            #region Наполнение элементов управления информацией из базы данных
            CmbProductClass.DisplayMemberPath = "Name";
            CmbProductClass.SelectedValuePath = "Id";
            CmbProductClass.ItemsSource = DBConnection.DBConnect.ProductClass.ToList();
            CmbProductClass.Text = product.ProductClass.Name;
            CmbProductGroup.DisplayMemberPath = "Name";
            CmbProductGroup.SelectedValuePath = "Id";
            CmbProductGroup.ItemsSource = DBConnection.DBConnect.ProductGroup.ToList();
            CmbProductGroup.Text = product.ProductGroup.Name;
            CmbUnit.DisplayMemberPath = "Name";
            CmbUnit.SelectedValuePath = "Id";
            CmbUnit.ItemsSource = DBConnection.DBConnect.Unit.ToList();
            CmbUnit.Text = product.Unit.Name;
            TxbDescription.Text = product.Description;
            TxbManufacturer.Text = product.Manufacturer;
            TxbManufacturerCountry.Text = product.ManufacturerCountry;
            TxbName.Text = product.Name;
            TxbQuantity.Text = product.Quantity.ToString();
            DPExpirationDate.Text = product.ExpirationDate.ToShortDateString();
            DPManufactureDate.Text = product.ManufactureDate.ToShortDateString();
            #endregion
            productId = product.Id;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }

        private void TxbNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void Txb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[\d\p{P}]";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TxbManufacturer.Text == null || TxbName.Text == null || TxbQuantity.Text == null ||
                CmbProductClass.Text == null || CmbProductGroup.Text == null || CmbUnit.Text == null ||
                DPExpirationDate.Text == null || DPManufactureDate.Text == null || TxbManufacturerCountry == null)
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
                        menshakova_inventoryControlEntities context = new menshakova_inventoryControlEntities();
                        #region Берем значения из элементов управления и вносим их в базу данных
                        var product = context.Product.Where(item => item.Id == productId).FirstOrDefault();
                        product.Manufacturer = TxbManufacturer.Text;
                        product.ManufactureDate = DateTime.Parse(DPManufactureDate.Text);
                        product.ManufacturerCountry = TxbManufacturerCountry.Text;
                        product.ProductGroupId = (CmbProductGroup.SelectedItem as ProductGroup).Id;
                        product.Description = TxbDescription.Text;
                        product.ExpirationDate = DateTime.Parse(DPExpirationDate.Text);
                        product.Name = TxbName.Text;
                        product.UnitId = (CmbUnit.SelectedItem as Unit).Id;
                        product.Quantity = double.Parse(TxbQuantity.Text);
                        product.ProductClassId = (CmbProductClass.SelectedItem as ProductClass).Id;
                        #endregion
                        //Сохраняем данные в БД
                        context.SaveChanges();
                        MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        //Возвращаемся обратно
                        Navigation.frameNav.GoBack();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        //MessageBox.Show(ex.Message.ToString(),
                        //    "Критическая ошибка",
                        //    MessageBoxButton.OK,
                        //    MessageBoxImage.Warning);
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                            foreach (DbValidationError err in validationError.ValidationErrors)
                            {
                                MessageBox.Show(err.ErrorMessage + "");
                            }
                        }
                    }
                }
            }
        }
    }
}
