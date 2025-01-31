using System.Collections.ObjectModel;
using System.Windows;

namespace wpfcrmKP
{
    public partial class Window1 : Window
    {
        // коллекция заказов для привязки к datagrid
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<Order> CompletedOrders { get; set; } // готовые заказы

        public Window1()
        {
            InitializeComponent();
            Orders = new ObservableCollection<Order>();
            CompletedOrders = new ObservableCollection<Order>();

            // привязка коллекций к datagrid
            DataGridOrders.ItemsSource = Orders;
            DataGridCompletedOrders.ItemsSource = CompletedOrders;
        }

        public void AddOrderToGrid(Order newOrder)
        {
            Orders.Add(newOrder);
        }

        private void ShowStatistics(object sender, RoutedEventArgs e)
        {
            // Создаем и показываем окно статистики, передаем коллекцию заказов
            var statisticsWindow = new StatisticsWindow(Orders);
            statisticsWindow.ShowDialog();
        }

        private void EditOrder(object sender, RoutedEventArgs e)
        {
            if (DataGridOrders.SelectedItem != null)
            {
                var selectedOrder = (Order)DataGridOrders.SelectedItem;  // получаем выбранный заказ

                var editWindow = new EditOrderWindow(selectedOrder);
                bool? result = editWindow.ShowDialog();  

                if (result == true)
                {
                    DataGridOrders.Items.Refresh(); // обновление после редактирования
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для редактирования.");
            }
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow
            {
                Owner = this 
            };
            addOrderWindow.ShowDialog(); 
        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            if (DataGridOrders.SelectedItem != null)
            {
                Orders.Remove((Order)DataGridOrders.SelectedItem);  
            }
            else
            {
                MessageBox.Show("Выберите заказ для удаления.");
            }
        }

        private void MoveToCompletedOrders(object sender, RoutedEventArgs e)
        {
            if (DataGridOrders.SelectedItem != null)
            {
                var selectedOrder = (Order)DataGridOrders.SelectedItem;

                // добавление в коллекцию готовых
                CompletedOrders.Add(selectedOrder);

                // удаление из в работе
                Orders.Remove(selectedOrder);

                DataGridOrders.Items.Refresh();
                DataGridCompletedOrders.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите заказ для перемещения.");
            }
        }
    }
}