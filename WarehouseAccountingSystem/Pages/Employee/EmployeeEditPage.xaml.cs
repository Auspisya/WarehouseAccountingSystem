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

namespace WarehouseAccountingSystem.Pages.Employee
{
    /// <summary>
    /// Логика взаимодействия для EmployeeEditPage.xaml
    /// </summary>
    public partial class EmployeeEditPage : Page
    {
        private int employeeId;
        public EmployeeEditPage(Models.Employee employee)
        {
            InitializeComponent();
            #region Наполнение элементов управления информацией из базы данных
            CmbGender.DisplayMemberPath = "Name";
            CmbGender.SelectedValuePath = "Id";
            CmbGender.ItemsSource = DBConnection.DBConnect.Gender.ToList();
            CmbMaterialLiability.DisplayMemberPath = "Name";
            CmbMaterialLiability.SelectedValuePath = "Id";
            CmbMaterialLiability.ItemsSource = DBConnection.DBConnect.MaterialLiability.ToList();
            CmbPosition.DisplayMemberPath = "Name";
            CmbPosition.SelectedValuePath = "Id";
            CmbPosition.ItemsSource = DBConnection.DBConnect.Position.ToList();
            TxbAddress.Text = employee.Address;
            DPDateOfBirth.Text = employee.DateOfBirth.ToShortDateString();
            DPDateOfEntry.Text = employee.DateOfEntry.ToShortDateString();
            TxbEHEducation.Text = employee.EmploymentHistory.Education;
            TxbEHNumber.Text = employee.EmploymentHistory.Number;
            DPEHRegistrationDate.Text = employee.EmploymentHistory.RegistrationDate.ToShortDateString();
            TxbEHSeries.Text = employee.EmploymentHistory.Series;
            TxbEHSpeciality.Text = employee.EmploymentHistory.Speciality;
            TxbSurname.Text = employee.Surname;
            TxbName.Text = employee.Name;
            if (employee.Patronymic == "")
            {
                TxbPatronymic.Text = "";
            }
            else
            {
                TxbPatronymic.Text = employee.Patronymic;
            }
            CmbGender.Text = employee.Gender.Name;
            TxbINNNumber.Text = employee.INN.Number;
            DPINNRegistrationDate.Text = employee.INN.RegistrationDate.ToShortDateString();
            TxbINNWhoRegistered.Text = employee.INN.WhoRegistered;
            CmbMaterialLiability.Text = employee.MaterialLiability.Name;
            DPPassportDateOfIssue.Text = employee.Passport.DateOfIssue.ToShortDateString();
            TxbPassportDivisionCode.Text = employee.Passport.DivisionCode;
            TxbPassportIssuedBy.Text = employee.Passport.PassportIssuedBy;
            TxbPassportNumber.Text = employee.Passport.Number;
            TxbPassportPlaceOfBirth.Text = employee.Passport.PlaceOfBirth;
            TxbPassportSeries.Text = employee.Passport.Series;
            TxbPhoneNumber.Text = employee.PhoneNumber;
            CmbPosition.Text = employee.Position.Name;
            TxbSNILSNumber.Text = employee.SNILS.Number;
            DPSNILSRegistrationDate.Text = employee.SNILS.RegistrationDate.ToShortDateString();
            #endregion
            employeeId = employee.Id;
        }
        private void Txb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[\d\p{P}]";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
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
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }

        private void CBShowGeneralInfo_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                SPGeneralInfo.Height = 1100;
                SPGeneralInfo.Visibility = Visibility.Visible;
                CBShowGeneralInfo.ToolTip = "Скрыть";
            }
            else
            {
                SPGeneralInfo.Height = 0;
                SPGeneralInfo.Visibility = Visibility.Hidden;
                CBShowGeneralInfo.ToolTip = "Показать";
            }
        }

        private void CBShowPassportInfo_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                SPPassportInfo.Height = 685;
                SPPassportInfo.Visibility = Visibility.Visible;
                CBShowPassportInfo.ToolTip = "Скрыть";
            }
            else
            {
                SPPassportInfo.Height = 0;
                SPPassportInfo.Visibility = Visibility.Hidden;
                CBShowPassportInfo.ToolTip = "Показать";
            }
        }

        private void CBShowSNILSInfo_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                SPSNILSInfo.Height = 230;
                SPSNILSInfo.Visibility = Visibility.Visible;
                CBShowSNILSInfo.ToolTip = "Скрыть";
            }
            else
            {
                SPSNILSInfo.Height = 0;
                SPSNILSInfo.Visibility = Visibility.Hidden;
                CBShowSNILSInfo.ToolTip = "Показать";
            }
        }

        private void CBShowINNInfo_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                SPINNInfo.Height = 335;
                SPINNInfo.Visibility = Visibility.Visible;
                CBShowINNInfo.ToolTip = "Скрыть";
            }
            else
            {
                SPINNInfo.Height = 0;
                SPINNInfo.Visibility = Visibility.Hidden;
                CBShowINNInfo.ToolTip = "Показать";
            }
        }

        private void CBShowEmploymentHistoryInfo_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                SPEmploymentHistoryInfo.Height = 570;
                SPEmploymentHistoryInfo.Visibility = Visibility.Visible;
                CBShowEmploymentHistoryInfo.ToolTip = "Скрыть";
            }
            else
            {
                SPEmploymentHistoryInfo.Height = 0;
                SPEmploymentHistoryInfo.Visibility = Visibility.Hidden;
                CBShowEmploymentHistoryInfo.ToolTip = "Показать";
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TxbAddress.Text == "" || TxbINNNumber.Text == "" || TxbINNWhoRegistered.Text == "" ||
                TxbName.Text == "" || TxbPhoneNumber.Text == "" || DPINNRegistrationDate.Text == "" || TxbEHEducation.Text == "" ||
                TxbEHNumber.Text == "" || DPEHRegistrationDate.Text == "" || TxbEHSeries.Text == "" || TxbEHSpeciality.Text == "" ||
                TxbPassportDivisionCode.Text == "" || TxbPassportIssuedBy.Text == "" || TxbPassportNumber.Text == "" || TxbPassportPlaceOfBirth.Text == "" ||
                TxbPassportSeries.Text == "" || TxbPhoneNumber.Text == "" || TxbSNILSNumber.Text == "" || TxbSurname.Text == "" || DPDateOfBirth.Text == "" ||
                DPDateOfEntry.Text == "" || DPINNRegistrationDate.Text == "" || DPPassportDateOfIssue.Text == "" || DPSNILSRegistrationDate.Text == "" ||
                CmbGender.Text == "" || CmbMaterialLiability.Text == "" || CmbPosition.Text == "")
            {
                MessageBox.Show("Нужно заполнить обязательные поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (TxbINNNumber.Text.Length < TxbINNNumber.MaxLength)
                {
                    MessageBox.Show($"ИНН не может быть меньше {TxbINNNumber.MaxLength} символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (TxbPhoneNumber.Text.Length < TxbPhoneNumber.MaxLength)
                {
                    MessageBox.Show($"Номер телефона не может быть меньше {TxbPhoneNumber.MaxLength} символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (TxbEHNumber.Text.Length < TxbEHNumber.MaxLength)
                {
                    MessageBox.Show($"Номер трудовой книжки не может быть меньше {TxbEHNumber.MaxLength} символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (TxbINNNumber.Text.Length < TxbINNNumber.MaxLength)
                {
                    MessageBox.Show($"Номер ИНН не может быть меньше {TxbINNNumber.MaxLength} символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (TxbPassportDivisionCode.Text.Length < TxbPassportDivisionCode.MaxLength)
                {
                    MessageBox.Show($"Код подразделения не может быть меньше {TxbPassportDivisionCode.MaxLength} символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (TxbPassportNumber.Text.Length < TxbPassportNumber.MaxLength)
                {
                    MessageBox.Show($"Номер паспорта не может быть меньше {TxbPassportNumber.MaxLength} символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (TxbPassportSeries.Text.Length < TxbPassportSeries.MaxLength)
                {
                    MessageBox.Show($"Серия паспорта не может быть меньше {TxbPassportSeries.MaxLength} символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (TxbSNILSNumber.Text.Length < TxbSNILSNumber.MaxLength)
                {
                    MessageBox.Show($"СНИЛС не может быть меньше {TxbSNILSNumber.MaxLength} символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                            var employee = context.Employee.Where(item => item.Id == employeeId).FirstOrDefault();
                            employee.PositionId = (CmbPosition.SelectedItem as Position).Id;
                            employee.Surname = TxbSurname.Text;
                            employee.Name = TxbName.Text;
                            employee.PhoneNumber = TxbPhoneNumber.Text;
                            employee.INN.Number = TxbINNNumber.Text;
                            employee.INN.WhoRegistered = TxbINNWhoRegistered.Text;
                            employee.INN.RegistrationDate = DateTime.Parse(DPINNRegistrationDate.Text);
                            employee.MaterialLiabilityId = (CmbMaterialLiability.SelectedItem as MaterialLiability).Id;
                            employee.Address = TxbAddress.Text;
                            employee.DateOfBirth = DateTime.Parse(DPDateOfBirth.Text);
                            employee.Patronymic = TxbPatronymic.Text;
                            employee.DateOfEntry = DateTime.Parse(DPDateOfEntry.Text);
                            employee.EmploymentHistory.Number = TxbEHNumber.Text;
                            employee.EmploymentHistory.Education = TxbEHEducation.Text;
                            employee.EmploymentHistory.Speciality = TxbEHSpeciality.Text;
                            employee.EmploymentHistory.Series = TxbEHSeries.Text;
                            employee.EmploymentHistory.RegistrationDate = DateTime.Parse(DPEHRegistrationDate.Text);
                            employee.GenderId = (CmbGender.SelectedItem as Gender).Id;
                            employee.SNILS.Number = TxbSNILSNumber.Text;
                            employee.SNILS.RegistrationDate = DateTime.Parse(DPSNILSRegistrationDate.Text);
                            employee.Passport.PassportIssuedBy = TxbPassportIssuedBy.Text;
                            employee.Passport.PlaceOfBirth = TxbPassportPlaceOfBirth.Text;
                            employee.Passport.Number = TxbPassportNumber.Text;
                            employee.Passport.Series = TxbPassportSeries.Text;
                            employee.Passport.DateOfIssue = DateTime.Parse(DPPassportDateOfIssue.Text);
                            employee.Passport.DivisionCode = TxbPassportDivisionCode.Text;
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
    }
}
