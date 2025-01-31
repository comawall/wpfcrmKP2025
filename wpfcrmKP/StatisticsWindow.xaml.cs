using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace wpfcrmKP
{
    public partial class StatisticsWindow : Window
    {
        private readonly ObservableCollection<Order> _orders;

        public StatisticsWindow(ObservableCollection<Order> orders)
        {
            InitializeComponent();
            _orders = orders;

            CalculateStatistics();
        }

        private void CalculateStatistics()
        {
            TotalOrders.Text = _orders.Count.ToString();

            double totalAmount = _orders.Sum(o => double.TryParse(o.ItemCount, out double itemCount) ? itemCount : 0);
            TotalAmount.Text = totalAmount.ToString("C");  

            double averageAmount = _orders.Count > 0 ? totalAmount / _orders.Count : 0;
            AverageAmount.Text = averageAmount.ToString("C"); 

            var pickupMethodCount = _orders.GroupBy(o => o.PickupMethod)
                                           .Select(group => new { PickupMethod = group.Key, Count = group.Count() })
                                           .ToList();

            PickupMethodCount.Text = string.Join(", ", pickupMethodCount.Select(x => $"{x.PickupMethod}: {x.Count}"));
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
