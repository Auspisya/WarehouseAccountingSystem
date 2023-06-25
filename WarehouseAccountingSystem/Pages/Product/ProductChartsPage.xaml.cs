using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using System.Data.Entity;
using WarehouseAccountingSystem.Models;
using WarehouseAccountingSystem.Classes;

namespace WarehouseAccountingSystem.Pages.Product
{
    /// <summary>
    /// Логика взаимодействия для ProductChartsPage.xaml
    /// </summary>
    public partial class ProductChartsPage : Page
    {
        private int productId;
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public ProductChartsPage(Models.Product product)
        {
            InitializeComponent();

            DataContext = this;
            productId = product.Id;
            var startDate = DateTime.Now.Date.AddMonths(-1);
            var endDate = DateTime.Now.Date;
            FillChartData(startDate, endDate);
        }

        private Tuple<Dictionary<DateTime, double>, Dictionary<DateTime, double>> LoadProductData(DateTime startDate, DateTime endDate)
        {
            using (var context = new menshakova_inventoryControlEntities())
            {
                var result =
                from s in context.ProductArrival
                where s.ArrivalDate >= startDate && s.ArrivalDate <= endDate && s.ProductId == productId
                group s by new { date = s.ArrivalDate } into g
                select new
                {
                    ArrivalDate = g.Key.date,
                    Quantity = g.Sum(x => x.Quantity),
                    Price = g.Max(x => x.Price)
                };
                var arrivalList = result.ToDictionary(t => t.ArrivalDate, t => t.Quantity);
                var result1 = from s in context.ProductConsumption
                where s.ConsumptionDate >= startDate && s.ConsumptionDate <= endDate && s.ProductId == productId
                group s by new { date = s.ConsumptionDate } into g
                select new
                {
                ArrivalDate = g.Key.date,
                Quantity = g.Sum(x => x.Quantity),
                Price = g.Max(x => x.Price)
                };
                var consumptionList = result1.ToDictionary(t => t.ArrivalDate, t => t.Quantity);
                for (var day = startDate; day <= endDate; day = day.AddDays(1))
                {
                    double arrival = 0;
                    if (arrivalList.ContainsKey(day)) arrival = arrivalList[day];
                    double consumption = 0;
                    if (consumptionList.ContainsKey(day)) consumption = consumptionList[day];
                    arrivalList[day] = arrival;
                    consumptionList[day] = consumption;
                }
                return new Tuple<Dictionary<DateTime, double>, Dictionary<DateTime, double>>(arrivalList, consumptionList);
            }
        }

        private void FillChartData(DateTime startDate, DateTime endDate)
        {
            var productDataList = LoadProductData(startDate, endDate);
            var incomes = new LineSeries
            {
                Title = "Приход",
                Values = new ChartValues<double>()
            };
            var expenses = new LineSeries
            {
                Title = "Расход",
                Values = new ChartValues<double>()
            };
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                incomes.Values.Add(productDataList.Item1[date]);
                expenses.Values.Add(productDataList.Item2[date]);
            }
            SeriesCollection = new SeriesCollection { incomes, expenses };
            Labels = Enumerable.Range(0, (endDate - startDate).Days + 1)
                .Select(d => startDate.AddDays(d).ToString("dd.MM.yyyy"))
                .ToArray();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameNav.GoBack();
        }
    }
}
