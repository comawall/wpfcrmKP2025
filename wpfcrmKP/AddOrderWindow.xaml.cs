using System.Windows;

namespace wpfcrmKP
{
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();
        }

        // добавление заказа
        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(OrderNumberBox.Text) || string.IsNullOrEmpty(ItemCountBox.Text) ||
                string.IsNullOrEmpty(TimeBox.Text) || string.IsNullOrEmpty(DishCodeBox.Text) || string.IsNullOrEmpty(PickupMethodBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            var newOrder = new Order
            {
                OrderNumber = OrderNumberBox.Text,
                ItemCount = ItemCountBox.Text,
                Time = TimeBox.Text,
                DishCode = DishCodeBox.Text,
                PickupMethod = PickupMethodBox.Text
            };

            var mainWindow = (Window1)Owner;
            mainWindow.AddOrderToGrid(newOrder);  

            this.Close();
        }
    }
}
