﻿using System;
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
using WarehouseAccountingSystem.Pages.ProductConsumption;

namespace WarehouseAccountingSystem.Pages.Employee
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            DGEmployee.ItemsSource = null;
            DGEmployee.ItemsSource = DBConnection.DBConnect.Employee.ToList();
        }

        private void BtnShowInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new EmployeeInfoPage((sender as Button).DataContext as Models.Employee));
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new EmployeeEditPage((sender as Button).DataContext as Models.Employee));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить данные?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {

            }
            else
            {
                try
                {
                    for (int i = 0; i < DGEmployee.SelectedItems.Count; i++)
                    {
                        Models.Employee employee = DGEmployee.SelectedItems[i] as Models.Employee;
                        DBConnection.DBConnect.Employee.Remove(employee);
                    }
                    DBConnection.DBConnect.SaveChanges();
                    MessageBox.Show("Данные успешно удалены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    DGEmployee.ItemsSource = null;
                    DGEmployee.ItemsSource = DBConnection.DBConnect.Employee.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Критическая обработка");
                }
            }
        }

        private void TxbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TxbSearch.Text = "";
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbSearch.Text != "")
                {
                    string searchString = TxbSearch.Text.ToLower();
                    var itemsList = DBConnection.DBConnect.Employee.ToList();
                    var searchResults = itemsList.Where(item => item.Surname.ToLower().Contains(searchString)).ToList();
                    DGEmployee.ItemsSource = searchResults.ToList();
                }
                else
                {
                    DGEmployee.ItemsSource = DBConnection.DBConnect.Employee.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DGEmployee.ItemsSource = null;
            DGEmployee.ItemsSource = DBConnection.DBConnect.Employee.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.Navigate(new EmployeeAddPage());
        }
    }
}
