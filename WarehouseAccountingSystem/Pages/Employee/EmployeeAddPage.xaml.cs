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
    /// Логика взаимодействия для EmployeeAddPage.xaml
    /// </summary>
    public partial class EmployeeAddPage : Page
    {
        public EmployeeAddPage()
        {
            InitializeComponent();
            CmbGender.DisplayMemberPath = "Name";
            CmbGender.SelectedValuePath = "Id";
            CmbGender.ItemsSource = DBConnection.DBConnect.Gender.ToList();
            CmbMaterialLiability.DisplayMemberPath = "Name";
            CmbMaterialLiability.SelectedValuePath = "Id";
            CmbMaterialLiability.ItemsSource = DBConnection.DBConnect.MaterialLiability.ToList();
            CmbPosition.DisplayMemberPath = "Name";
            CmbPosition.SelectedValuePath = "Id";
            CmbPosition.ItemsSource = DBConnection.DBConnect.Position.ToList();
        }
        private void Txb_KeyDown(object sender, KeyEventArgs e)
        {

            Regex pattern = new Regex("^[a-zA-Z]+$");

            if (!pattern.IsMatch(e.Key.ToString()))
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TxbAddress.Text == "" || TxbINNNumber.Text == "" || TxbINNWhoRegistered.Text == "" ||
                TxbName.Text == "" || TxbPhoneNumber.Text == "" || DPINNRegistrationDate.Text == "" || TxbEHEducation.Text == "" ||
                TxbEHNumber.Text == "" || DPEHRegistrationDate.Text == "" || TxbEHSeries.Text == "" || TxbEHSpeciality.Text == "" ||
                TxbPassportDivisionCode.Text == "" || TxbPassportIssuedBy.Text == "" || TxbPassportNumber.Text == "" || TxbPassportPlaceOfBirth.Text == "" ||
                TxbPassportSeries.Text == "" || TxbPhoneNumber.Text == "" || TxbSNILSNumber.Text == "" || TxbSurname.Text == "" || DPDateOfBirth.Text == "" ||
                DPDateOfEntry.Text == "" || DPINNRegistrationDate.Text == "" || DPPassportDateOfIssue.Text == "" || DPSNILSRegistrationDate.Text == "" ||
                CmbGender.Text == "" || CmbMaterialLiability.Text == "" || CmbPosition.Text == "" )
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
                    if (MessageBox.Show("Вы точно хотите добавить данные?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        try
                        {
                            INN inn = new INN()
                            {
                                Number = TxbINNNumber.Text,
                                WhoRegistered = TxbINNWhoRegistered.Text,
                                RegistrationDate = DateTime.Parse(DPINNRegistrationDate.Text)
                            };

                            SNILS snils = new SNILS()
                            {
                                Number = TxbSNILSNumber.Text,
                                RegistrationDate = DateTime.Parse(DPSNILSRegistrationDate.Text)
                            };

                            Passport passport = new Passport()
                            {
                                DateOfIssue = DateTime.Parse(DPPassportDateOfIssue.Text),
                                DivisionCode = TxbPassportDivisionCode.Text,
                                Number = TxbPassportNumber.Text,
                                PassportIssuedBy = TxbPassportIssuedBy.Text,
                                PlaceOfBirth = TxbPassportPlaceOfBirth.Text,
                                Series = TxbPassportSeries.Text
                            };

                            EmploymentHistory employmentHistory = new EmploymentHistory()
                            {
                                Education = TxbEHEducation.Text,
                                Number = TxbEHNumber.Text,
                                RegistrationDate = DateTime.Parse(DPEHRegistrationDate.Text),
                                Series = TxbEHSeries.Text,
                                Speciality = TxbEHSpeciality.Text
                            };
                            Models.Employee employee = new Models.Employee()
                            {
                                Address = TxbAddress.Text,
                                DateOfBirth = DateTime.Parse(DPDateOfBirth.Text),
                                DateOfEntry = DateTime.Parse(DPDateOfEntry.Text),
                                EmploymentHistoryId = employmentHistory.Id,
                                Gender = CmbGender.SelectedItem as Gender,
                                INNId = inn.Id,
                                MaterialLiability = CmbMaterialLiability.SelectedItem as MaterialLiability,
                                Name = TxbName.Text,
                                PassportId = passport.Id,
                                Patronymic = TxbPatronymic.Text,
                                PhoneNumber = TxbPhoneNumber.Text,
                                Position = CmbPosition.SelectedItem as Position,
                                SNILSId = snils.Id,
                                Surname = TxbSurname.Text
                            };
                            DBConnection.DBConnect.INN.Add(inn);
                            DBConnection.DBConnect.SNILS.Add(snils);
                            DBConnection.DBConnect.Passport.Add(passport);
                            DBConnection.DBConnect.EmploymentHistory.Add(employmentHistory);
                            DBConnection.DBConnect.Employee.Add(employee);
                            DBConnection.DBConnect.SaveChanges();
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
}
