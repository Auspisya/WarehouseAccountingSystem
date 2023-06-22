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
using WarehouseAccountingSystem.Models;

namespace WarehouseAccountingSystem.Pages.ProductArrival
{
    /// <summary>
    /// Логика взаимодействия для ProductArrivalInfoPage.xaml
    /// </summary>
    public partial class ProductArrivalInfoPage : Page
    {
        public ProductArrivalInfoPage(Models.ProductArrival productArrival)
        {
            InitializeComponent();
            #region Наполнение элементов управления информацией из базы данных
            if (productArrival.Product.Description == null)
            {
                TxbDescription.Text = "Без описания";
            }
            else
            {
                TxbDescription.Text = productArrival.Product.Description;
            }
            TxbArrivalDate.Text = productArrival.ArrivalDate.ToShortDateString();
            TxbArrivalQuantity.Text = productArrival.Quantity.ToString();
            if (productArrival.Employee.Patronymic == null)
            {
                TxbEmployeeAccepted.Text = productArrival.Employee.Surname + " " + productArrival.Employee.Name;
            }
            else
            {
                TxbEmployeeAccepted.Text = productArrival.Employee.Surname + " " + productArrival.Employee.Name + " " + productArrival.Employee.Patronymic;
            }
            TxbName.Text = "[" + productArrival.Product.Name + "]";
            TxbProcurationDateOfIssue.Text = productArrival.ProcurationDateOfIssue.ToShortDateString();
            TxbProcurationNumber.Text = productArrival.ProcurationNumber;
            TxbProvider.Text = productArrival.Provider.Name;
            TxbUnit.Text = productArrival.Product.Unit.Name;
            #endregion
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }
    }
}
