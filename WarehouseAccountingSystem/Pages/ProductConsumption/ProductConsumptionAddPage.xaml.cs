using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
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

namespace WarehouseAccountingSystem.Pages.ProductConsumption
{
    /// <summary>
    /// Логика взаимодействия для ProductConsumptionAddPage.xaml
    /// </summary>
    public partial class ProductConsumptionAddPage : Page
    {
        public ProductConsumptionAddPage()
        {
            InitializeComponent();
            CmbEmployeePassed.DisplayMemberPath = "FullName";
            CmbEmployeePassed.SelectedValuePath = "Id";
            CmbEmployeePassed.ItemsSource = DBConnection.DBConnect.Employee.ToList();
            CmbProductName.DisplayMemberPath = "Name";
            CmbProductName.SelectedValuePath = "Id";
            CmbProductName.ItemsSource = DBConnection.DBConnect.Product.ToList();
            CmbReceiver.DisplayMemberPath = "Name";
            CmbReceiver.SelectedValuePath = "Id";
            CmbReceiver.ItemsSource = DBConnection.DBConnect.Receiver.ToList();
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
            if (CBChooseReceiver.IsChecked == true)
            {
                if (CmbEmployeePassed.Text == "" || CmbProductName.Text == "" || DPConsumptionDate.Text == "" || DPProcurationDateOfIssue.Text == "" ||
                TxbProcurationNumber.Text == "" || CmbReceiver.Text == "" || TxbQuantity.Text == "" || TxbUnitPrice.Text == "")
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
                            Models.ProductConsumption productConsumption = new Models.ProductConsumption()
                            {
                                Receiver = CmbReceiver.SelectedItem as Models.Receiver,
                                Product = CmbProductName.SelectedItem as Models.Product,
                                ConsumptionDate = DateTime.Parse(DPConsumptionDate.Text),
                                Employee = CmbEmployeePassed.SelectedItem as Employee,
                                Price = decimal.Parse(TxbPrice.Text),
                                ProcurationDateOfIssue = DateTime.Parse(DPProcurationDateOfIssue.Text),
                                ProcurationNumber = TxbProcurationNumber.Text,
                                Quantity = double.Parse(TxbQuantity.Text),
                                UnitPrice = decimal.Parse(TxbUnitPrice.Text)
                            };
                            var productId = CmbProductName.SelectedItem as Models.Product;
                            menshakova_inventoryControlEntities context = new menshakova_inventoryControlEntities();
                            var product = context.Product.Where(item => item.Id == productId.Id).FirstOrDefault();
                            if (product.Quantity < double.Parse(TxbQuantity.Text))
                            {
                                MessageBox.Show("Ошибка! Количество расхода заявленного товара больше, чем товара на складе!");
                            }
                            else
                            {
                                DBConnection.DBConnect.ProductConsumption.Add(productConsumption);
                                DBConnection.DBConnect.SaveChanges();
                                product.Quantity = product.Quantity - double.Parse(TxbQuantity.Text);
                                context.SaveChanges();
                                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                Navigation.frameNav.GoBack();
                            }
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
                if (CmbEmployeePassed.Text == "" || CmbProductName.Text == "" || DPConsumptionDate.Text == "" || DPProcurationDateOfIssue.Text == "" ||
                DPReceiverINNRegistrationDate.Text == "" || TxbProcurationNumber.Text == "" || TxbReceiverAddress.Text == "" ||
                TxbReceiverINNNumber.Text == "" || TxbReceiverINNWhoRegistered.Text == "" || TxbReceiverName.Text == "" || TxbReceiverPhoneNumber.Text == "" ||
                TxbQuantity.Text == "" || TxbUnitPrice.Text == "")
                {
                    MessageBox.Show("Нужно заполнить обязательные поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                                Number = TxbReceiverINNNumber.Text,
                                RegistrationDate = DateTime.Parse(DPReceiverINNRegistrationDate.Text),
                                WhoRegistered = TxbReceiverINNWhoRegistered.Text
                            };

                            Models.Receiver receiver = new Models.Receiver()
                            {
                                Address = TxbReceiverAddress.Text,
                                INNId = inn.Id,
                                Name = TxbReceiverName.Text,
                                PhoneNumber = TxbReceiverPhoneNumber.Text
                            };

                            Models.ProductConsumption productConsumption = new Models.ProductConsumption()
                            {
                                ReceiverId = receiver.Id,
                                Product = CmbProductName.SelectedItem as Models.Product,
                                ConsumptionDate = DateTime.Parse(DPConsumptionDate.Text),
                                Employee = CmbEmployeePassed.SelectedItem as Employee,
                                Price = decimal.Parse(TxbPrice.Text),
                                ProcurationDateOfIssue = DateTime.Parse(DPProcurationDateOfIssue.Text),
                                ProcurationNumber = TxbProcurationNumber.Text,
                                Quantity = double.Parse(TxbQuantity.Text),
                                UnitPrice = decimal.Parse(TxbUnitPrice.Text)
                            };
                            var productId = CmbProductName.SelectedItem as Models.Product;
                            menshakova_inventoryControlEntities context = new menshakova_inventoryControlEntities();
                            var product = context.Product.Where(item => item.Id == productId.Id).FirstOrDefault();
                            if (product.Quantity < double.Parse(TxbQuantity.Text))
                            {
                                MessageBox.Show("Ошибка! Количество расхода заявленного товара больше, чем товара на складе!");
                            }
                            else
                            {
                                DBConnection.DBConnect.INN.Add(inn);
                                DBConnection.DBConnect.Receiver.Add(receiver);
                                DBConnection.DBConnect.ProductConsumption.Add(productConsumption);
                                DBConnection.DBConnect.SaveChanges();
                                product.Quantity = product.Quantity - double.Parse(TxbQuantity.Text);
                                context.SaveChanges();
                                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                Navigation.frameNav.GoBack();
                            }
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

        private void CBAddReceiver_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                SPAddReceiver.Height = 505;
                SPAddReceiver.Visibility = Visibility.Visible;
                SPAddReceiver.ToolTip = "Скрыть";
                CBChooseReceiver.IsChecked = false;
                SPChooseReceiver.Height = 0;
                SPChooseReceiver.Visibility = Visibility.Hidden;
                SPChooseReceiver.ToolTip = "Показать";
            }
            else
            {
                SPAddReceiver.Height = 0;
                SPAddReceiver.Visibility = Visibility.Hidden;
                SPAddReceiver.ToolTip = "Показать";
            }
        }

        private void CBChooseReceiver_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                SPChooseReceiver.Height = 110;
                SPChooseReceiver.Visibility = Visibility.Visible;
                SPChooseReceiver.ToolTip = "Скрыть";
                CBAddReceiver.IsChecked = false;
                SPAddReceiver.Height = 0;
                SPAddReceiver.Visibility = Visibility.Hidden;
                SPAddReceiver.ToolTip = "Показать";
            }
            else
            {
                SPChooseReceiver.Height = 0;
                SPChooseReceiver.Visibility = Visibility.Hidden;
                SPChooseReceiver.ToolTip = "Показать";
            }
        }

        private void CmbProductName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var description = (CmbProductName.SelectedItem as Models.Product).Description;
            TxbDescription.Text = description.ToString();
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
    }
}
