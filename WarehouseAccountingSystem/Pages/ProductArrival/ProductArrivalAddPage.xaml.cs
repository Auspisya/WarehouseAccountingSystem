using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using System.Xml.Linq;
using WarehouseAccountingSystem.Classes;
using WarehouseAccountingSystem.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WarehouseAccountingSystem.Pages.ProductArrival
{
    /// <summary>
    /// Логика взаимодействия для ProductArrivalAddPage.xaml
    /// </summary>
    public partial class ProductArrivalAddPage : Page
    {
        public ProductArrivalAddPage()
        {
            InitializeComponent();
            CmbEmployeeAccepted.DisplayMemberPath = "FullName";
            CmbEmployeeAccepted.SelectedValuePath = "Id";
            CmbEmployeeAccepted.ItemsSource = DBConnection.DBConnect.Employee.ToList();
            CmbProductName.DisplayMemberPath = "Name";
            CmbProductName.SelectedValuePath = "Id";
            CmbProductName.ItemsSource = DBConnection.DBConnect.Product.ToList();
            CmbProvider.DisplayMemberPath = "Name";
            CmbProvider.SelectedValuePath = "Id";
            CmbProvider.ItemsSource = DBConnection.DBConnect.Provider.ToList();
        }
        private void TxbNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CBChooseProvider.IsChecked == true)
            {
                if (CmbEmployeeAccepted.Text == "" || CmbProductName.Text == "" || DPArrivalDate.Text == "" || DPProcurationDateOfIssue.Text == "" ||
                TxbProcurationNumber.Text == "" || CmbProvider.Text == "" || TxbQuantity.Text == "" || TxbUnitPrice.Text == "")
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
                            Models.ProductArrival productArrival = new Models.ProductArrival()
                            {
                                Provider = CmbProvider.SelectedItem as Models.Provider,
                                Product = CmbProductName.SelectedItem as Models.Product,
                                ArrivalDate = DateTime.Parse(DPArrivalDate.Text),
                                Employee = CmbEmployeeAccepted.SelectedItem as Models.Employee,
                                Price = decimal.Parse(TxbPrice.Text),
                                ProcurationDateOfIssue = DateTime.Parse(DPProcurationDateOfIssue.Text),
                                ProcurationNumber = TxbProcurationNumber.Text,
                                Quantity = double.Parse(TxbQuantity.Text),
                                UnitPrice = decimal.Parse(TxbUnitPrice.Text)
                            };
                            DBConnection.DBConnect.ProductArrival.Add(productArrival);
                            DBConnection.DBConnect.SaveChanges();
                            var productId = CmbProductName.SelectedItem as Models.Product;
                            menshakova_inventoryControlEntities context = new menshakova_inventoryControlEntities();
                            var product = context.Product.Where(item => item.Id == productId.Id).FirstOrDefault();
                            product.Quantity = product.Quantity + double.Parse(TxbQuantity.Text);
                            context.SaveChanges();
                            MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Navigation.frameNav.GoBack();
                        }
                        catch (DbEntityValidationException ex)
                        {
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
            else
            {
                if (CmbEmployeeAccepted.Text == "" || CmbProductName.Text == "" || DPArrivalDate.Text == "" || DPProcurationDateOfIssue.Text == "" ||
                DPProviderINNRegistrationDate.Text == "" || TxbProcurationNumber.Text == "" || TxbProviderAddress.Text == "" ||
                TxbProviderINNNumber.Text == "" || TxbProviderINNWhoRegistered.Text == "" || TxbProviderName.Text == "" || TxbProviderPhoneNumber.Text == "" ||
                TxbQuantity.Text == "" || TxbUnitPrice.Text == "")
                {
                    MessageBox.Show("Нужно заполнить обязательные поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    if (TxbProviderINNNumber.Text.Length < 12)
                    {
                        MessageBox.Show("ИНН не может быть меньше 12 символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if (TxbProviderPhoneNumber.Text.Length < 12)
                    {
                        MessageBox.Show("Номер телефона не может быть меньше 12 символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        if (MessageBox.Show("Вы точно хотите добавить данные? Пожалуйста, проверьте корректность введённых данных, отредактировать в дальнейшем их будет невозможно!", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        {

                        }
                        else
                        {
                            try
                            {
                                INN inn = new INN()
                                {
                                    Number = TxbProviderINNNumber.Text,
                                    RegistrationDate = DateTime.Parse(DPProviderINNRegistrationDate.Text),
                                    WhoRegistered = TxbProviderINNWhoRegistered.Text
                                };

                                Models.Provider provider = new Models.Provider()
                                {
                                    Address = TxbProviderAddress.Text,
                                    INNId = inn.Id,
                                    Name = TxbProviderName.Text,
                                    PhoneNumber = TxbProviderPhoneNumber.Text
                                };

                                Models.ProductArrival productArrival = new Models.ProductArrival()
                                {
                                    ProviderId = provider.Id,
                                    Product = CmbProductName.SelectedItem as Models.Product,
                                    ArrivalDate = DateTime.Parse(DPArrivalDate.Text),
                                    Employee = CmbEmployeeAccepted.SelectedItem as Models.Employee,
                                    Price = decimal.Parse(TxbPrice.Text),
                                    ProcurationDateOfIssue = DateTime.Parse(DPProcurationDateOfIssue.Text),
                                    ProcurationNumber = TxbProcurationNumber.Text,
                                    Quantity = double.Parse(TxbQuantity.Text),
                                    UnitPrice = decimal.Parse(TxbUnitPrice.Text)
                                };
                                DBConnection.DBConnect.INN.Add(inn);
                                DBConnection.DBConnect.Provider.Add(provider);
                                DBConnection.DBConnect.ProductArrival.Add(productArrival);
                                DBConnection.DBConnect.SaveChanges();
                                var productId = CmbProductName.SelectedItem as Models.Product;
                                menshakova_inventoryControlEntities context = new menshakova_inventoryControlEntities();
                                var product = context.Product.Where(item => item.Id == productId.Id).FirstOrDefault();
                                product.Quantity = product.Quantity + double.Parse(TxbQuantity.Text);
                                context.SaveChanges();
                                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                Navigation.frameNav.GoBack();
                            }
                            catch (DbEntityValidationException ex)
                            {
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

        private void TxbUnitPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxbQuantity.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите количество товара");
            }
            else 
            {
                if (TxbUnitPrice.Text == "")
                {
                    TxbPrice.Text = "";
                }
                else
                {
                    double unitPrice = double.Parse(TxbUnitPrice.Text);
                    double price = double.Parse(TxbQuantity.Text) * unitPrice;
                    TxbPrice.Text = price.ToString();
                }
            }
        }

        private void CBAddProvider_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                SPAddProvider.Height = 505;
                SPAddProvider.Visibility = Visibility.Visible;
                SPAddProvider.ToolTip = "Скрыть";
                CBChooseProvider.IsChecked = false;
                SPChooseProvider.Height = 0;
                SPChooseProvider.Visibility = Visibility.Hidden;
                SPChooseProvider.ToolTip = "Показать";
            }
            else
            {
                SPAddProvider.Height = 0;
                SPAddProvider.Visibility = Visibility.Hidden;
                SPAddProvider.ToolTip = "Показать";
            }
        }

        private void CBChooseProvider_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                SPChooseProvider.Height = 110;
                SPChooseProvider.Visibility = Visibility.Visible;
                SPChooseProvider.ToolTip = "Скрыть";
                CBAddProvider.IsChecked = false;
                SPAddProvider.Height = 0;
                SPAddProvider.Visibility = Visibility.Hidden;
                SPAddProvider.ToolTip = "Показать";
            }
            else
            {
                SPChooseProvider.Height = 0;
                SPChooseProvider.Visibility = Visibility.Hidden;
                SPChooseProvider.ToolTip = "Показать";
            }
        }

        private void CmbProductName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var description = (CmbProductName.SelectedItem as Models.Product).Description;
            TxbDescription.Text = description.ToString();
        }
    }
}
