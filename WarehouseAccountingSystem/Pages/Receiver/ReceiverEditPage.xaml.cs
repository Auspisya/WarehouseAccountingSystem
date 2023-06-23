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
using WarehouseAccountingSystem.Classes;
using WarehouseAccountingSystem.Models;

namespace WarehouseAccountingSystem.Pages.Receiver
{
    /// <summary>
    /// Логика взаимодействия для ReceiverEditPage.xaml
    /// </summary>
    public partial class ReceiverEditPage : Page
    {
        private int receiverId;
        public ReceiverEditPage(Models.Receiver receiver)
        {
            InitializeComponent();
            #region Наполнение элементов управления информацией из базы данных
            TxbAddress.Text = receiver.Address;
            TxbINNNumber.Text = receiver.INN.Number;
            TxbINNWhoRegistered.Text = receiver.INN.WhoRegistered;
            TxbName.Text = receiver.Name;
            TxbPhoneNumber.Text = receiver.PhoneNumber;
            DPINNRegistrationDate.Text = receiver.INN.RegistrationDate.ToShortDateString();
            #endregion
            receiverId = receiver.Id;
        }

        private void TxbNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TxbAddress.Text == "" || TxbINNNumber.Text == "" || TxbINNWhoRegistered.Text == "" ||
                TxbName.Text == "" || TxbPhoneNumber.Text == "" || DPINNRegistrationDate.Text == "")
            {
                MessageBox.Show("Нужно заполнить обязательные поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (TxbINNNumber.Text.Length < 12)
                {
                    MessageBox.Show("ИНН не может быть меньше 12 символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (TxbPhoneNumber.Text.Length < 12)
                {
                    MessageBox.Show("Номер телефона не может быть меньше 12 символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    if (MessageBox.Show("Вы точно хотите редактировать данные?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        try
                        {
                            menshakova_inventoryControlEntities context = new menshakova_inventoryControlEntities();
                            #region Берем значения из элементов управления и вносим их в базу данных
                            var receiver = context.Receiver.Where(item => item.Id == receiverId).FirstOrDefault();
                            receiver.Name = TxbName.Text;
                            receiver.PhoneNumber = TxbPhoneNumber.Text;
                            receiver.Address = TxbAddress.Text;
                            receiver.INN.Number = TxbINNNumber.Text;
                            receiver.INN.WhoRegistered = TxbINNWhoRegistered.Text;
                            receiver.INN.RegistrationDate = DateTime.Parse(DPINNRegistrationDate.Text);
                            #endregion
                            context.SaveChanges();
                            MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }
    }
}
