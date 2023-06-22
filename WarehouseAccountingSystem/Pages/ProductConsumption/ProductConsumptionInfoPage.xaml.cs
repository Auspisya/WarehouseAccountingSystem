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

namespace WarehouseAccountingSystem.Pages.ProductConsumption
{
    /// <summary>
    /// Логика взаимодействия для ProductConsumptionInfoPage.xaml
    /// </summary>
    public partial class ProductConsumptionInfoPage : Page
    {
        public ProductConsumptionInfoPage(Models.ProductConsumption productConsumption)
        {
            InitializeComponent();
            #region Наполнение элементов управления информацией из базы данных
            if (productConsumption.Product.Description == null)
            {
                TxbDescription.Text = "Без описания";
            }
            else
            {
                TxbDescription.Text = productConsumption.Product.Description;
            }
            TxbConsumptionDate.Text = productConsumption.ConsumptionDate.ToShortDateString();
            TxbConsumptionQuantity.Text = productConsumption.Quantity.ToString();
            if (productConsumption.Employee.Patronymic == null)
            {
                TxbEmployeePassed.Text = productConsumption.Employee.Surname + " " + productConsumption.Employee.Name;
            }
            else
            {
                TxbEmployeePassed.Text = productConsumption.Employee.Surname + " " + productConsumption.Employee.Name + " " + productConsumption.Employee.Patronymic;
            }
            TxbName.Text = productConsumption.Product.Name;
            TxbProcurationDateOfIssue.Text = productConsumption.ProcurationDateOfIssue.ToShortDateString();
            TxbProcurationNumber.Text = productConsumption.ProcurationNumber;
            TxbReceiver.Text = productConsumption.Receiver.Name;
            TxbUnit.Text = productConsumption.Product.Unit.Name;
            #endregion
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }
    }
}
