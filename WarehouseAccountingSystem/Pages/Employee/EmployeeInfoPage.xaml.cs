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

namespace WarehouseAccountingSystem.Pages.Employee
{
    /// <summary>
    /// Логика взаимодействия для EmployeeInfoPage.xaml
    /// </summary>
    public partial class EmployeeInfoPage : Page
    {
        public EmployeeInfoPage(Models.Employee employee)
        {
            InitializeComponent();
            #region Наполнение элементов управления информацией из базы данных
            TxbAddress.Text = employee.Address;
            TxbDateOfBirth.Text = employee.DateOfBirth.ToShortDateString();
            TxbDateOfEntry.Text = employee.DateOfEntry.ToShortDateString();
            TxbEHEducation.Text = employee.EmploymentHistory.Education;
            TxbEHNumber.Text = employee.EmploymentHistory.Number;
            TxbEHRegistrationDate.Text = employee.EmploymentHistory.RegistrationDate.ToShortDateString();
            TxbEHSeries.Text = employee.EmploymentHistory.Series;
            TxbEHSpeciality.Text = employee.EmploymentHistory.Speciality;
            if (employee.Patronymic == "")
            {
                TxbFullName.Text = "[" + employee.Surname + " " + employee.Name + "]";
            }
            else 
            {
                TxbFullName.Text = "[" + employee.Surname + " " + employee.Name + " " + employee.Patronymic + "]";
            }
            TxbGender.Text = employee.Gender.Name;
            TxbINNNumber.Text = employee.INN.Number;
            TxbINNRegistrationDate.Text = employee.INN.RegistrationDate.ToShortDateString();
            TxbINNWhoRegistered.Text = employee.INN.WhoRegistered;
            TxbMaterialLiability.Text = employee.MaterialLiability.Name;
            TxbPassportDateOfIssue.Text = employee.Passport.DateOfIssue.ToShortDateString();
            TxbPassportDivisionCode.Text = employee.Passport.DivisionCode;
            TxbPassportIssuedBy.Text = employee.Passport.PassportIssuedBy;
            TxbPassportNumber.Text = employee.Passport.Number;
            TxbPassportPlaceOfBirth.Text = employee.Passport.PlaceOfBirth;
            TxbPassportSeries.Text = employee.Passport.Series;
            TxbPhoneNumber.Text = employee.PhoneNumber;
            TxbPosition.Text = employee.Position.Name;
            TxbSNILSNumber.Text = employee.SNILS.Number;
            TxbSNILSRegistrationDate.Text = employee.SNILS.RegistrationDate.ToShortDateString();
            #endregion
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
                SPGeneralInfo.Height = 700;
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
                SPPassportInfo.Height = 600;
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
                SPSNILSInfo.Height = 200;
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
                SPINNInfo.Height = 300;
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
                SPEmploymentHistoryInfo.Height = 500;
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
    }
}
